using System;
using Comfort.Common;
using EFT;

namespace JET.Server.World
{
    public class ServerWorld : ClientWorld
    {
        private void Awake()
        {
            Singleton<ServerWorld>.Create(this);
            RegisterNetworkInteractionObjects();
            
            InitializeVariables();
        }


        private void InitializeVariables()
        {
            list_0.Clear();
            foreach (var worldInteractiveObject in worldInteractiveObject_0)
            {
                list_0.Add(worldInteractiveObject.GetStatusInfo(true));
            }

            Singleton<GameWorld>.Instance.RegisterBorderZones();
        }
    }
}