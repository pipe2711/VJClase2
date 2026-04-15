using System;

public class PlayerStats 
{
    public static int score;

    public static Action<int> OnScoreChanged;

    public static void AddScore(int value)
    {
        score += value;
        OnScoreChanged?.Invoke(score);
    }
}