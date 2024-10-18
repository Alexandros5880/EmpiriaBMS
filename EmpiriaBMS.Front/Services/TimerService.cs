using EmpiriaBMS.Core;
using EmpiriaBMS.Core.Services.EmailService;
using Logging;
using System.Collections.Concurrent;
using System.Timers;

namespace EmpiriaBMS.Front.Services
{
    public class TimerService : IDisposable
    {
        private bool disposedValue;
        private TimeSpan prefixTime = TimeSpan.FromHours(77); // Set Pred Default worked Hours For Debug
        private readonly Dictionary<string, System.Threading.Timer> _timers = new();
        private readonly ConcurrentDictionary<string, TimeSpan> _elapsedTime = new();
        private readonly ConcurrentDictionary<string, TimeSpan> _pausedTime = new();
        private readonly System.Timers.Timer _dailyResetTimer;
        private readonly IEmailService _emailService;
        private readonly IDataProvider _dataProvider;
        private readonly LoggerManager _logger;

        public TimerService(
            IEmailService emailService,
            IDataProvider dataProvider,
            LoggerManager logger
        )
        {
            _emailService = emailService;
            _dataProvider = dataProvider;
            _logger = logger;
            _dailyResetTimer = new System.Timers.Timer(GetMillisecondsUntilMidnight());
            _dailyResetTimer.Elapsed += OnDailyReset;
            _dailyResetTimer.AutoReset = false;
            _dailyResetTimer.Start();
        }

        public bool IsRunning(string userId) =>
            _timers.ContainsKey(userId);

        public void StartTimer(string userId)
        {
            if (IsRunning(userId))
            {
                StopTimer(userId);
            }

            _elapsedTime[userId] = TimeSpan.Zero;
            System.Threading.Timer timer = new System.Threading.Timer(Callback, userId, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            _timers[userId] = timer;
        }

        private void Callback(object state)
        {
            var userId = (string)state;

            if (!_pausedTime.ContainsKey(userId)
                && _elapsedTime.TryGetValue(userId, out TimeSpan elapsedTime))
            {
                if (elapsedTime == TimeSpan.Zero)
                {
                    _elapsedTime.AddOrUpdate(
                    userId,
                    prefixTime,
                    (key, oldTime) => oldTime.Add(prefixTime)
                );

                    return;
                }
            }

            _elapsedTime.AddOrUpdate(
                userId,
                TimeSpan.FromSeconds(1),
                (key, oldTime) => oldTime.Add(TimeSpan.FromSeconds(1))
            );
        }

        public TimeSpan StopTimer(string userId)
        {
            if (_timers.TryGetValue(userId, out System.Threading.Timer timer))
            {
                var timeNow = GetElapsedTime(userId);
                _pausedTime.AddOrUpdate(
                    userId,
                    timeNow,
                    (key, oldTime) => oldTime.Add(timeNow)
                );

                timer.Dispose();
                _timers.Remove(userId);

                return GetPausedTime(userId);
            }
            return TimeSpan.Zero;
        }

        public TimeSpan GetElapsedTime(string userId)
        {
            if (_elapsedTime.TryGetValue(userId, out TimeSpan elapsedTime))
            {
                return elapsedTime;
            }
            return TimeSpan.Zero;
        }

        public TimeSpan GetPausedTime(string userId)
        {
            if (_pausedTime.TryGetValue(userId, out TimeSpan pausedTime))
            {
                return pausedTime;
            }
            return TimeSpan.Zero;
        }

        public void ResetPausedTime(string userId)
        {
            _pausedTime[userId] = TimeSpan.Zero;
        }

        public void ClearTimer(string userId)
        {
            if (_timers.TryGetValue(userId, out System.Threading.Timer timer))
            {
                timer.Dispose();
                _timers.Remove(userId);
                _elapsedTime.TryRemove(userId, out var ignoredElapsed);
                _pausedTime.TryRemove(userId, out var ignoredPaused);
            }
        }

        private async void OnDailyReset(object sender, ElapsedEventArgs e)
        {
            foreach (var userId in _timers.Keys.ToList())
            {
                if (IsRunning(userId))
                {
                    var timeNow = GetElapsedTime(userId);
                    StopTimer(userId);
                    try
                    {
                        var user = await _dataProvider.Users.Get(Convert.ToInt32(userId));
                        var emails = await _dataProvider.Users.GetEmails(Convert.ToInt32(userId));
                        var emailsStr = emails.Select(e => e.Address).ToList();
                        List<string> recipients = new List<string>(emailsStr);
                        var subject = "EmbiriaBMS Daily Timer Reset";
                        var body = $"Mr/Ms. {user.LastName} {user.FirstName}, you forgot to spend your hours today, your hours are {timeNow.DisplayDHMS()}";
                        await _emailService.SendEmailAsync(subject, body, recipients.ToArray());
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"\nException in TimerService.OnDailyReset(object sender, ElapsedEventArgs e): {ex.Message}.\nInner: {ex.InnerException?.Message}.");
                    }
                }
            }

            // Reset the timer to trigger at the next midnight
            _dailyResetTimer.Interval = GetMillisecondsUntilMidnight();
            _dailyResetTimer.Start();
        }

        private double GetMillisecondsUntilMidnight()
        {
            var now = DateTime.Now;
            var midnight = now.Date.AddDays(1);
            return (midnight - now).TotalMilliseconds;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dailyResetTimer?.Dispose();
                    foreach (var timer in _timers.Values)
                    {
                        timer.Dispose();
                    }
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
