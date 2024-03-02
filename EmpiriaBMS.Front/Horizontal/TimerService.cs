using System.Collections.Concurrent;

namespace EmpiriaBMS.Front.Horizontal;

public class TimerService
{
    private readonly Dictionary<string, Timer> _timers = new();
    private readonly ConcurrentDictionary<string, TimeSpan> _elapsedTime = new();
    private readonly ConcurrentDictionary<string, TimeSpan> _pausedTime = new();

    public bool IsRunning(string userId) =>
        _timers.ContainsKey(userId);

    public void StartTimer(string userId)
    {
        if (IsRunning(userId))
        {
            StopTimer(userId);
        }

        _elapsedTime[userId] = TimeSpan.Zero;
        Timer timer = new Timer(Callback, userId, TimeSpan.Zero, TimeSpan.FromSeconds(1));
        _timers[userId] = timer;
    }

    private void Callback(object state)
    {
        var userId = (string)state;
        _elapsedTime.AddOrUpdate(
            userId,
            TimeSpan.FromSeconds(1),
            (key, oldTime) => oldTime.Add(TimeSpan.FromSeconds(1))
        );
    }

    public void StopTimer(string userId)
    {
        if (_timers.TryGetValue(userId, out Timer timer))
        {
            var timeNow = GetElapsedTime(userId);
            _pausedTime.AddOrUpdate(
                userId,
                timeNow,
                (key, oldTime) => oldTime.Add(timeNow)
            );

            timer.Dispose();
            _timers.Remove(userId);
        }
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
}