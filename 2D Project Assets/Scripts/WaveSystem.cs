using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    [SerializeField]
    private Wave[] waves;
    [SerializeField]
    private EnemySpawner enemySpawner;
    public int currentWaveIndex = 0;
    public TextMeshProUGUI Wave;
    public TextMeshProUGUI EnemyCount;
    private PlayerAction playerAction;

    public int CurrentWava => currentWaveIndex + 1;
    public int MaxWave => waves.Length;


    private void Awake()
    {
        playerAction = FindObjectOfType<PlayerAction>();
    }
        public void NextWave()
    {
        if (currentWaveIndex < waves.Length)
        {
            enemySpawner.StartWave(waves[currentWaveIndex]);
        }
        else
        {
            Over();
        }
        currentWaveIndex++;
    }

    private void Over()
    {
        Debug.Log("All waves are completed!");
        playerAction.GameClear();
    }
    public void Update()
    {
        Wave.text = "Wave: " + currentWaveIndex + "/" + MaxWave;
        EnemyCount.text = enemySpawner.CurrentEnemyCount + "/" + enemySpawner.MaxEnemyCount;
    }
}
[System.Serializable]
public struct Wave
{
    public float spawnTime;
    public int maxEnemyCount;
    public GameObject[] enemyPrefabs;
}