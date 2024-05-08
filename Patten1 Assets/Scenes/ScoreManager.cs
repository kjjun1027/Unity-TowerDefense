using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI에 표시할 텍스트
    private int score = 0; // 현재 점수

    // 싱글톤 인스턴스
    private static ScoreManager instance;

    // 싱글톤 인스턴스 반환
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

    // 점수 추가 메서드
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // UI 업데이트 메서드
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
