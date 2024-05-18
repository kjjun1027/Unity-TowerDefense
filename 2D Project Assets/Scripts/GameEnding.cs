using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    public TextMeshProUGUI Ending;
    public void GameOver()
    {
        Ending.text = "Game Over";
    }
    public void GameClear()
    {
        Ending.text = "Game Clear";
    }
}
