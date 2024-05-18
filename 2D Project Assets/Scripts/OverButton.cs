using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OverButton : MonoBehaviour
{
    public Button button1;
    public Button button2;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(Restart);
        button2.onClick.AddListener(ExitGame);
    }

    private void Restart()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        FindObjectOfType<OverScene>().Restart();
    }
    private void ExitGame()
    {
        Debug.Log("버튼이 클릭되었습니다!");
        Application.Quit();
    }
}
