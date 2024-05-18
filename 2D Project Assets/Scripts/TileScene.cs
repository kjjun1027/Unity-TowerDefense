using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScene : MonoBehaviour
{
    public GameObject gameRulePanel;
    public GameObject filterPanel;
    public GameObject originalUIPanel;
    public GameObject GameScene;
    public GameObject OverScene;
    private WaveSystem waveSystem;

    public void Start()
    {
        originalUIPanel.SetActive(true);
        filterPanel.SetActive(false);
        gameRulePanel.SetActive(false);
        GameScene.SetActive(false);
        OverScene.SetActive(false);
        waveSystem = FindObjectOfType<WaveSystem>();
    }

    public void StartGame()
    {
        GameScene.SetActive(true);
        SceneManager.Instance.LoadGameScene();
        originalUIPanel.SetActive(false);
        filterPanel.SetActive(false);
        gameRulePanel.SetActive(false);
        waveSystem.NextWave();
    }

    public void ShowGameRules()
    {
        originalUIPanel.SetActive(false);
        filterPanel.SetActive(true);
        gameRulePanel.SetActive(true);
    }

    public void CloseGameRules()
    {
        filterPanel.SetActive(false);
        gameRulePanel.SetActive(false);
        originalUIPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
