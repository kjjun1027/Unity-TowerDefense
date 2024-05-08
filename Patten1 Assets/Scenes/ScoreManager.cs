using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // UI�� ǥ���� �ؽ�Ʈ
    private int score = 0; // ���� ����

    // �̱��� �ν��Ͻ�
    private static ScoreManager instance;

    // �̱��� �ν��Ͻ� ��ȯ
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

    // ���� �߰� �޼���
    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    // UI ������Ʈ �޼���
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score;
    }
}
