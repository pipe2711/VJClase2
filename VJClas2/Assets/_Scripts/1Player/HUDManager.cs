using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDManager : MonoBehaviour
{
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        UpdateScore(PlayerStats.score);
    }

    void OnEnable()
    {
        PlayerHealth.OnHealthChanged += UpdateHearts;
        PlayerStats.OnScoreChanged += UpdateScore;
    }

    void OnDisable()
    {
        PlayerHealth.OnHealthChanged -= UpdateHearts;
        PlayerStats.OnScoreChanged -= UpdateScore;
    }

    void UpdateHearts(int currentHealth, int maxHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }

    void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

}