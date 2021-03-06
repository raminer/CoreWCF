﻿using System;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace Helpers
{
    public static class ClientHelper
    {
        private static TimeSpan s_debugTimeout = TimeSpan.FromMinutes(20);

        public static BasicHttpBinding GetBufferedModeBinding()
        {
            var binding = new BasicHttpBinding();
            ApplyDebugTimeouts(binding);
            return binding;
        }

        public static BasicHttpsBinding GetBufferedModeHttpsBinding()
        {
            var binding = new BasicHttpsBinding();
            ApplyDebugTimeouts(binding);
            return binding;
        }

        public static BasicHttpBinding GetStreamedModeBinding()
        {
            var binding = new BasicHttpBinding
            {
                TransferMode = TransferMode.Streamed
            };
            ApplyDebugTimeouts(binding);
            return binding;
        }

        public static NetHttpBinding GetBufferedModeWebSocketBinding()
        {
            var binding = new NetHttpBinding();
            binding.WebSocketSettings.TransportUsage = WebSocketTransportUsage.Always;
            ApplyDebugTimeouts(binding);
            return binding;
        }

        public static NetHttpBinding GetStreamedModeWebSocketBinding()
        {
            var binding = new NetHttpBinding
            {
                TransferMode = TransferMode.Streamed
            };
            binding.WebSocketSettings.TransportUsage = WebSocketTransportUsage.Always;
            ApplyDebugTimeouts(binding);
            return binding;
        }

        private static void ApplyDebugTimeouts(Binding binding)
        {
            if (Debugger.IsAttached)
            {
                binding.OpenTimeout =
                    binding.CloseTimeout =
                    binding.SendTimeout =
                    binding.ReceiveTimeout = s_debugTimeout;
            }
        }
    }
}

