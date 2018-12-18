using System;
using System.Timers;
using Jiratt.Services.Events;
using Prism.Events;

namespace Jiratt.Services.Worker {
    public class GlobalTimer {
        private readonly IEventAggregator _eventAggregator;
        private readonly Timer _timer;

        private TimeSpan _period;

        public GlobalTimer(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<PubSubEvent<StartTimerEvent>>().Subscribe(OnStartTimer);
            _eventAggregator.GetEvent<PubSubEvent<StopTimerEvent>>().Subscribe(OnStopTimer);

            _period = TimeSpan.FromSeconds(1);

            _timer = new Timer();
            _timer.Interval = _period.TotalMilliseconds;
            _timer.AutoReset = true;
            _timer.Elapsed += _timer_Elapsed;
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e) {
            _eventAggregator.GetEvent<PubSubEvent<TimerTickEvent>>().Publish(new TimerTickEvent(_period));
        }

        private void OnStartTimer(StartTimerEvent obj) {
            _timer.Start();
            _eventAggregator.GetEvent<PubSubEvent<TimerStartedEvent>>().Publish(new TimerStartedEvent());
        }

        private void OnStopTimer(StopTimerEvent obj) {
            _timer.Stop();
            _eventAggregator.GetEvent<PubSubEvent<TimerStoppedEvent>>().Publish(new TimerStoppedEvent());
        }
        
    }
}