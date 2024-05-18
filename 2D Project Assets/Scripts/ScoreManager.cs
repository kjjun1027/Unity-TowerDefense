using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager instance;

    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<ScoreManager>();

                if (instance == null)
                {
                    GameObject obj = new GameObject("ScoreManager");
                    instance = obj.AddComponent<ScoreManager>();
                }
            }
            return instance;
        }
    }

    private int currentScore = 0;
    private int highestScore = 20;

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI currentScoreText1;
    public TextMeshProUGUI highestScoreText;


    public void AddScore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > highestScore)
        {
            highestScore = currentScore;
        }
        UpdateUIText();
    }

    public void UpdateUIText()
    {
        currentScoreText.text = "Score: " + currentScore;
        currentScoreText1.text = "Score: " + currentScore;
        highestScoreText.text = "Best Score: " + highestScore;
    }

    public void ResetScore()
    {
        currentScore = 0;
        UpdateUIText();
    }

    private void OnDestroy()
    {
        instance = null;
    }
}
