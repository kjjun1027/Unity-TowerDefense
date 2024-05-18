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
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<TileScene>().StartGame();
    }

    private void ShowGameRules()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<TileScene>().ShowGameRules();
    }

    private void CloseGameRules()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<TileScene>().CloseGameRules();
    }

    private void ExitGame()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        Application.Quit();
    }
}
