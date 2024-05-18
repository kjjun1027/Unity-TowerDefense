using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TileScene : MonoBehaviour
{
    public GameObject gameRulePanel;
    public GameObject filterPanel;
    public GameObject originalUIPanel; // ���� ��Ģ �г��� ���� ���� UI �г�
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
        SceneManager.Instance.LoadGameScene(); // "GameScene"�� ���� �� �̸��� �°� �����ؾ� �մϴ�.
        originalUIPanel.SetActive(false);
        filterPanel.SetActive(false);
        gameRulePanel.SetActive(false);
        waveSystem.NextWave();
    }

    public void ShowGameRules()
    {
        originalUIPanel.SetActive(false); // ���� ��Ģ �г��� ���� ���� UI �г��� ��Ȱ��ȭ�մϴ�.
        filterPanel.SetActive(true); // ��ο� ���͸� Ȱ��ȭ�մϴ�.
        gameRulePanel.SetActive(true); // GameRule �г��� Ȱ��ȭ�մϴ�.
    }

    public void CloseGameRules()
    {
        filterPanel.SetActive(false); // ��ο� ���͸� ��Ȱ��ȭ�մϴ�.
        gameRulePanel.SetActive(false); // GameRule �г��� ��Ȱ��ȭ�մϴ�.
        originalUIPanel.SetActive(true); // ���� ��Ģ �г��� ���� �� ���� UI �г��� �ٽ� Ȱ��ȭ�մϴ�.
    }

    public void ExitGame()
    {
        Application.Quit(); // ������ �����մϴ�. (����� ���¿����� ����)
    }
}
