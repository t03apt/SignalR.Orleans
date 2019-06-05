﻿using System.Diagnostics;

namespace SignalR.Orleans.Core
{
    [DebuggerDisplay("{DebuggerDisplay,nq}")]
    internal struct ConnectionGrainKey
    {
        private string DebuggerDisplay => $"HubName: '{HubName}', Id: '{Id}'";
        public string HubName { get; set; }
        public string Id { get; set; }

        public ConnectionGrainKey(string primaryKey) : this()
        {
            Parse(primaryKey);
        }

        public void Parse(string primaryKey)
        {
            var pkArray = primaryKey.Split(':');

            HubName = pkArray[0];
            Id = pkArray[1];
        }

        public static string Build(string hubName, string key)
            => $"{hubName}:{key}";
    }
}