using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileButton : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;

    private void Start()
    {
        button1.onClick.AddListener(StartGame);
        button2.onClick.AddListener(ShowGameRules);
        button3.onClick.AddListener(CloseGameRules);
        button4.onClick.AddListener(ExitGame);
    }

    private void StartGame()
    {
        Debug.Log("��ư�� Ŭ���Ǿ����ϴ�!");
        FindObjectOfType<TileScene>().StartGame();
    }

    private void ShowGameRules()
    {
        Debug.Log("��ư�� Ŭ���Ǿ����ϴ�!");
        FindObjectOfType<TileScene>().ShowGameRules();
    }

    private void CloseGameRules()
    {
        Debug.Log("��ư�� Ŭ���Ǿ����ϴ�!");
        FindObjectOfType<TileScene>().CloseGameRules();
    }

    private void ExitGame()
    {
        Debug.Log("��ư�� Ŭ���Ǿ����ϴ�!");
        Application.Quit();
    }
}
