using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverScene : MonoBehaviour
{
    public GameObject OverScene1;
    public GameObject GameScene;
    public GameObject player;
    private WaveSystem waveSystem;
    void Start()
    {
        Debug.Log("Plz");
        waveSystem = FindObjectOfType<WaveSystem>();
    }

    public void Restart()
    {
        ScoreManager.Instance.ResetScore();
        waveSystem.currentWaveIndex = 0;
        GameScene.SetActive(true);
        OverScene1.SetActive(false);
        Transform playerTransrom = player.GetComponent<Transform>();
        playerTransrom.position = new Vector3(0, 0, 0);
        waveSystem.NextWave();
        SceneManager.Instance.LoadGameScene();
    }   
}
