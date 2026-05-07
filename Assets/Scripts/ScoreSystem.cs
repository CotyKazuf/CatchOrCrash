using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private Image[] scoreDigits;
    [SerializeField] private Image[] highScoreDigits;
    [SerializeField] private Image[] finalScoreDigits;

    [SerializeField] private Sprite[] digitSprites;

    [SerializeField] private int pointsPerFruit = 1;

    private int score = 0;
    private int highScore = 0;

    private void Start()
    {
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        ShowNumber(score, scoreDigits);
        ShowNumber(highScore, highScoreDigits);
        ShowNumber(score, finalScoreDigits);
    }

    public void AddScore()
    {
        score += pointsPerFruit;

        if (score > 99999)
        {
            score = 99999;
        }

        ShowNumber(score, scoreDigits);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();

            ShowNumber(highScore, highScoreDigits);
        }
    }

    public void ShowFinalScore()
    {
        ShowNumber(score, finalScoreDigits);
    }

    private void ShowNumber(int number, Image[] digitImages)
    {
        number = Mathf.Clamp(number, 0, 99999);

        for (int i = 0; i < digitImages.Length; i++)
        {
            int divisor = (int)Mathf.Pow(10, 4 - i);
            int digit = (number / divisor) % 10;
            bool isLeadingZero = number < divisor;

            if (isLeadingZero && i < digitImages.Length - 1)
            {
                digitImages[i].enabled = false;
            }
            else
            {
                digitImages[i].enabled = true;
                digitImages[i].sprite = digitSprites[digit];
            }
        }
    }
}