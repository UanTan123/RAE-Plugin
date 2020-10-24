using Exiled.API.Enums;
using Exiled.API.Features;
using System;
using Server = Exiled.Events.Handlers.Server;
using MEC;
using System.Collections.Generic;

namespace RoundAutoEnd
{
    public class Plugin : Plugin<Config>
    {
        private static readonly Lazy<Plugin> LazyInstance = new Lazy<Plugin>(() => new Plugin());
        public static Plugin Instance => LazyInstance.Value;
        public override PluginPriority Priority { get; } = PluginPriority.Medium;

        public EventHandlers events;

        public override string Prefix => "RAE";

        private Plugin() {}
        public List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();

        public override void OnEnabled()
        {
            RegisterEvents();

            Log.Info("RAE on");
            Log.Info("Copyright 2020. UN10 All rights reserved.");
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();

            Log.Info("RAE off");
            Log.Info("Copyright 2020. UN10 All rights reserved.");
            base.OnDisabled();
        }

        public void RegisterEvents()
        {
            events = new EventHandlers(this);

            Server.RoundStarted += events.OnRoundStart;
            Server.RoundEnded += events.OnRoundEnd;
            Server.RestartingRound += events.OnRoundRestarting;
        }

        public void UnregisterEvents()
        {
            Server.RoundStarted -= events.OnRoundStart;
            Server.RoundEnded -= events.OnRoundEnd;
            Server.RestartingRound -= events.OnRoundRestarting;

            events = null;
        }
    }
}
