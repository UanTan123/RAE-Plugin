using Exiled.API.Features;
using Exiled.Events.EventArgs;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundAutoEnd
{
    public class EventHandlers
    {
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private readonly Plugin plugin;

        public void OnRoundStart()
        {
            plugin.Coroutines.Add(Timing.RunCoroutine(RAE()));
        }

        public void OnRoundEnd(RoundEndedEventArgs ev)
        {
            foreach (CoroutineHandle coroutine in plugin.Coroutines)
                Timing.KillCoroutines(coroutine);
        }

        public void OnRoundRestarting()
        {
            foreach (CoroutineHandle coroutine in plugin.Coroutines)
                Timing.KillCoroutines(coroutine);
        }

        private IEnumerator<float> RAE()
        {
            yield return Timing.WaitForSeconds(Plugin.Instance.Config.EndMessage);
            RoundSummary.RoundLock = false;
            RoundSummary.singleton.ForceEnd();
            Log.Info($"요청하신 대로, {Plugin.Instance.Config.EndMessage}초 후 라운드가 종료되었습니다.");
        }
    }
}
