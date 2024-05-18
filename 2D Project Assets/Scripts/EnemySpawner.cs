using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyHPSliderPrefab;
    [SerializeField]
    private Transform canvasTransform;
    [SerializeField]
    private Transform[] spawnPoints; // 스폰 포인트 배열
    [SerializeField]
    private Transform playerTransform; // 플레이어의 Transform
    private Wave currentWave;
    private WaveSystem waveSystem;
    private int currentEnemyCount=1;
    private List<Enemy> enemyList;

    public List<Enemy> EnemyList => enemyList;
    public int CurrentEnemyCount => currentEnemyCount;
    public int MaxEnemyCount => currentWave.maxEnemyCount;

    private void Awake()
    {
        enemyList = new List<Enemy>();
    }

    public void StartWave(Wave wave)
    {
        currentWave = wave;
        currentEnemyCount = currentWave.maxEnemyCount;

        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        int spawnEnemyCount = 0;
        while (spawnEnemyCount < currentWave.maxEnemyCount)
        {
            int enemyIndex = Random.Range(0, currentWave.enemyPrefabs.Length);
            GameObject clone = Instantiate(currentWave.enemyPrefabs[enemyIndex]);
            Enemy enemy = clone.GetComponent<Enemy>();

            // 무작위로 스폰 포인트 선택
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnPointIndex];

            // 적을 무작위 스폰 포인트에 배치
            clone.transform.position = spawnPoint.position;

            // 적 설정
            enemy.Setup(this, playerTransform); // 플레이어의 위치를 전달
            enemyList.Add(enemy);

            SpawnEnemyHPSilder(clone);
            spawnEnemyCount++;

            yield return new WaitForSeconds(currentWave.spawnTime);
        }

    }

    public void DestroyEnemy(EnemyDestroyType type, Enemy enemy, int score)
    {
        if (type == EnemyDestroyType.Kill)
        {
            if (ScoreManager.Instance != null)
            {
                // 적이 파괴될 때 점수를 추가합니다.
                ScoreManager.Instance.AddScore(score);
            }
        }
        currentEnemyCount--;
        enemyList.Remove(enemy);
        Destroy(enemy.gameObject);
    }

    private void SpawnEnemyHPSilder(GameObject enemy)
    {
        GameObject sliderClone = Instantiate(enemyHPSliderPrefab);
        sliderClone.transform.SetParent(canvasTransform);
        sliderClone.transform.localScale = Vector3.one;
        sliderClone.GetComponent<SilderPositionAutoSetter>().Setup(enemy.transform);
        sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHP>());
    }
}
