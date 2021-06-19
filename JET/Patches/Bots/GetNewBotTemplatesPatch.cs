using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Comfort.Common;
using EFT;
using JET.Utilities.Patching;
using WaveInfo = GClass929; // Field: Role (choose first one displayed as "Role")
using BotsPresets = GClass362; // Method: GetNewProfile (higher GClass number)
using BotData = GInterface15; // Method: ChooseProfile
using PoolManager = GClass1168; // CancellationToken: PoolsCancellationToken
using JobPriority = GClass2146; // Delegate: Immediate

namespace JET.Patches.Bots
{
    public class GetNewBotTemplatesPatch : GenericPatch<GetNewBotTemplatesPatch>
    {
        public static FieldInfo __field;
        private static Func<BotsPresets, BotData, Profile> _getNewProfileFunc;

        public GetNewBotTemplatesPatch() : base(prefix: nameof(PatchPrefix))
        {
            // compile-time checks
            _ = nameof(WaveInfo.Difficulty);
            _ = nameof(BotsPresets.GetNewProfile);
            _ = nameof(BotData.PrepareToLoadBackend);
            _ = nameof(PoolManager.LoadBundlesAndCreatePools);
            _ = nameof(JobPriority.General);

            // creating delegate
            _getNewProfileFunc = typeof(BotsPresets)
                .GetMethod(nameof(BotsPresets.GetNewProfile), BindingFlags.NonPublic | BindingFlags.Instance)
                .CreateDelegate(typeof(Func<BotsPresets, BotData, Profile>)) as Func<BotsPresets, BotData, Profile>;
        }

        protected override MethodBase GetTargetMethod()
        {
            return typeof(BotsPresets).GetMethod(nameof(BotsPresets.CreateProfile), BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        }

        public static bool PatchPrefix(ref Task<Profile> __result, BotsPresets __instance, BotData data)
        {
            /*
                in short when client wants new bot and GetNewProfile() return null (if not more available templates or they don't satisfied by Role and Difficulty condition)
                then client gets new piece of WaveInfo collection (with Limit = 30 by default) and make request to server
                but use only first value in response (this creates a lot of garbage and cause freezes)
                after patch we request only 1 template from server

                along with other patches this one causes to call data.PrepareToLoadBackend(1) gets the result with required role and difficulty:
                new[] { new WaveInfo() { Limit = 1, Role = role, Difficulty = difficulty } }
                then perform request to server and get only first value of resulting single element collection
            */

            var session = Utilities.Config.BackEndSession;
            var taskScheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var taskAwaiter = (Task<Profile>)null;

            // try get profile from cache
            var profile = _getNewProfileFunc(__instance, data);

            if (profile == null)
            {
                // load from server
                Debug.LogError("[JET]: Loading bot profile from server");
                var source = data.PrepareToLoadBackend(1).ToList();
                taskAwaiter = session.LoadBots(source).ContinueWith(GetFirstResult, taskScheduler);
            }
            else
            {
                // return cached profile
                Debug.LogError("[JET]: Loading bot profile from cache");
                taskAwaiter = Task.FromResult(profile);
            }

            // load bundles for bot profile
            var continuation = new Continuation(taskScheduler);

            __result = taskAwaiter.ContinueWith(continuation.LoadBundles, taskScheduler).Unwrap();

            return false;
        }

        private static Profile GetFirstResult(Task<Profile[]> task)
        {
            return task.Result[0];
        }

        private struct Continuation
        {
            Profile Profile;
            TaskScheduler TaskScheduler { get; }

            public Continuation(TaskScheduler taskScheduler)
            {
                Profile = null;
                TaskScheduler = taskScheduler;
            }

            public Task<Profile> LoadBundles(Task<Profile> task)
            {
                Profile = task.Result;

                var loadTask = Singleton<PoolManager>.Instance
                    .LoadBundlesAndCreatePools(PoolManager.PoolsCategory.Raid, 
                                               PoolManager.AssemblyType.Local, 
                                               Profile.GetAllPrefabPaths(false).ToArray(), 
                                               JobPriority.General, 
                                               null, 
                                               default(CancellationToken));

                return loadTask.ContinueWith(GetProfile, TaskScheduler);
            }

            private Profile GetProfile(Task task)
            {
                return Profile;
            }
        }
    }
}
