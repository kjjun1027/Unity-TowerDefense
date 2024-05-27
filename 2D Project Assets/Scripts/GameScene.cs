using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : MonoBehaviour
{
    public GameObject GameScene1;
    public GameObject Grid;
    public GameObject player;
    public GameObject MainPanel;
    public GameObject PausePanel;
    public int i=0;
    public Vector3 newPosition = new Vector3(0, 0, 0);
    private List<GameObject> deactivatedProjectiles = new List<GameObject>();
    private List<GameObject> deactivatedEnemies = new List<GameObject>();
    private WaveSystem waveSystem;
    private EnemySpawner enemySpawner;
    public CameraFollow cameraFollow;
    private PlayerHp playerHp;
    private PlayerAction playerAction;
    void Start()
    {
        Transform playerTransrom = player.GetComponent<Transform>();
        playerTransrom.position = newPosition;
        GameScene1.SetActive(true);
        MainPanel.SetActive(true);
        PausePanel.SetActive(false);
        waveSystem = FindObjectOfType<WaveSystem>();
        enemySpawner = FindObjectOfType<EnemySpawner>();
        cameraFollow = FindObjectOfType<CameraFollow>();
        cameraFollow.SetPlayer(player.transform);
        playerHp = FindObjectOfType<PlayerHp>();  
        playerAction = FindObjectOfType<PlayerAction>();
    }
    public void Update()
    {
        if(playerAction.Resetnumber == 1)
        {
            playerHp.Resetto();
            playerAction.Resetnumber = 0;
        }
        cameraFollow.FollowPlayer();
        if (enemySpawner.CurrentEnemyCount == 0)
        {
            waveSystem.NextWave();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowPause();
        }
    }

    public void ShowPause()
    {
        DeactivateAllEnemies();
        DeactivateAllProjectiles();
        MainPanel.SetActive(false);
        PausePanel.SetActive(true);
        player.SetActive(false);
        Grid.SetActive(false);
    }
    public void ClosePause()
    {
        ActivateAllEnemies();
        DeactivateAllProjectiles1();
        MainPanel.SetActive(true);
        PausePanel.SetActive(false);
        player.SetActive(true);
        Grid.SetActive(true);
    }
    public void ReStart()
    {
        playerHp.Resetto();
        waveSystem.currentWaveIndex = 0;
        ScoreManager.Instance.ResetScore();
        DestroyAllEnemies();
        DeactivateAllProjectiles2();
        player.SetActive(true);
        Grid.SetActive(true);
        MainPanel.SetActive(true);
        PausePanel.SetActive(false);
        Transform playerTransrom = player.GetComponent<Transform>();
        playerTransrom.position = newPosition;
        waveSystem.NextWave();
        SceneManager.Instance.LoadGameScene();
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void DeactivateAllProjectiles()
    {
        GameObject[] projectiles = GameObject.FindGameObjectsWithTag("Projectile");
        foreach (GameObject projectile in projectiles)
        {
            projectile.SetActive(false);
            deactivatedProjectiles.Add(projectile);
        }
    }

    public void DeactivateAllProjectiles1()
    {
        foreach (GameObject projectile in deactivatedProjectiles)
        {
            projectile.SetActive(true);
        }
        deactivatedProjectiles.Clear();
    }

    public void DeactivateAllProjectiles2()
    {
        foreach (GameObject projectile in deactivatedProjectiles)
        {
            Destroy(projectile);
        }
        deactivatedProjectiles.Clear();
    }

    public void DeactivateAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            enemy.SetActive(false);
            deactivatedEnemies.Add(enemy);
        }
    }

    public void ActivateAllEnemies()
    {
        foreach (GameObject enemy in deactivatedEnemies)
        {
            enemy.SetActive(true);
        }
        deactivatedEnemies.Clear();
    }

    public void DestroyAllEnemies()
    {
        foreach (GameObject enemy in deactivatedEnemies)
        {
            Destroy(enemy);
        }
        deactivatedEnemies.Clear();
    }

}
