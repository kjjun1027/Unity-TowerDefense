using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScene : MonoBehaviour
{
    public GameObject gameRulePanel;
    public GameObject filterPanel;
    public GameObject originalUIPanel; // 게임 규칙 패널을 열기 전의 UI 패널
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
        SceneManager.Instance.LoadGameScene(); // "GameScene"은 실제 씬 이름에 맞게 변경해야 합니다.
        originalUIPanel.SetActive(false);
        filterPanel.SetActive(false);
        gameRulePanel.SetActive(false);
        waveSystem.NextWave();
    }

    public void ShowGameRules()
    {
        originalUIPanel.SetActive(false); // 게임 규칙 패널을 열기 전의 UI 패널을 비활성화합니다.
        filterPanel.SetActive(true); // 어두운 필터를 활성화합니다.
        gameRulePanel.SetActive(true); // GameRule 패널을 활성화합니다.
    }

    public void CloseGameRules()
    {
        filterPanel.SetActive(false); // 어두운 필터를 비활성화합니다.
        gameRulePanel.SetActive(false); // GameRule 패널을 비활성화합니다.
        originalUIPanel.SetActive(true); // 게임 규칙 패널을 닫은 후 원래 UI 패널을 다시 활성화합니다.
    }

    public void ExitGame()
    {
        Application.Quit(); // 게임을 종료합니다. (빌드된 상태에서만 동작)
    }
}
