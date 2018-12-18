using System;

namespace Jiratt.Services.Events {
    public class TimerTickEvent {
        public TimeSpan TimeElapsedSinceLastTick { get; }

        public TimerTickEvent(TimeSpan timeElapsedSinceLastTick) {
            TimeElapsedSinceLastTick = timeElapsedSinceLastTick;
        }
    }
}