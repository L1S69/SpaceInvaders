using System;

public static class EventManager
{
    public static Action EnemyDestroyed;
    public static void OnEnemyDestroyed()
    {
        EnemyDestroyed?.Invoke();
    }

    public static Action<float> DirectionChanged;
    public static void OnDirectionChanged(float num)
    {
        DirectionChanged?.Invoke(num);
    }

    public static Action GameOver;
    public static void OnGameOver()
    {
        GameOver?.Invoke();
    }

    public static Action<int> ScoreChanged;
    public static void OnScoreChanged(int num)
    {
        ScoreChanged?.Invoke(num);
    }

    public static Action<int> HPChanged;
    public static void OnHPChanged(int num)
    {
        HPChanged?.Invoke(num);
    }
}
