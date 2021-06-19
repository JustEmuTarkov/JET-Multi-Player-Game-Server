using System.Collections.Generic;
using UnityEngine.Networking;

#pragma warning disable 618

namespace JET.Server.Connection
{
    public static class Config
    {
        public static ConnectionConfig GetConfiguration()
        {
            var config = GetConnectionConfig();

            for (var i = 0; i < 102; i++)
            {
                var item = config.AddChannel(QosType.Reliable);
                var item2 = config.AddChannel(QosType.Unreliable);

                config.MakeChannelsSharedOrder(new List<byte> {item, item2});
            }

            return config;
        }

        private static ConnectionConfig GetConnectionConfig()
        {
            return new ConnectionConfig
            {
                DisconnectTimeout = 4000U,
                NetworkDropThreshold = 25,
                OverflowDropThreshold = 80,
                AcksType = ConnectionAcksType.Acks128,
                Channels =
                {
                    new ChannelQOS(QosType.ReliableFragmented),
                    new ChannelQOS(QosType.ReliableFragmented),
                    new ChannelQOS(QosType.ReliableFragmented)
                }
            };
        }
    }
}