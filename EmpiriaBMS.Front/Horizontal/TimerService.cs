using System.Collections.Concurrent;

namespace EmpiriaBMS.Front.Horizontal;

public class TimerService
{
    private readonly Dictionary<string, Timer> _timers = new();
    private readonly ConcurrentDictionary<string, TimeSpan> _elapsedTime = new();
    private readonly ConcurrentDictionary<string, TimeSpan> _pausedTime = new();

    public bool IsRunning(string userId) =>
        _timers.ContainsKey(userId);

    public void StartTimer(string userId, TimeSpan? startTime = null)
    {
        if (IsRunning(userId))
        {
            StopTimer(userId);
        }
        _elapsedTime[userId] = TimeSpan.Zero;            
        Timer timer = new Timer(Callback, userId, startTime ?? _pausedTime[userId], TimeSpan.FromSeconds(1));
        _pausedTime[userId] = TimeSpan.Zero;
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
        _pausedTime.AddOrUpdate(
            userId,
            _pausedTime[userId],
            (key, oldTime) => oldTime.Add(_pausedTime[userId])
        );

        if (_timers.TryGetValue(userId, out Timer timer))
        {
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
}