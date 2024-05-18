using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameButton : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public Button button4;


    private void Start()
    {
        button1.onClick.AddListener(Restart);
        button2.onClick.AddListener(ShowPause);
        button3.onClick.AddListener(ClosePause);
        button4.onClick.AddListener(ExitGame);
    }

    private void Restart()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<GameScene>().ReStart();
    }

    private void ShowPause()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<GameScene>().ShowPause();
    }

    private void ClosePause()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<GameScene>().ClosePause();
    }

    private void ExitGame()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        Application.Quit();
    }
}
