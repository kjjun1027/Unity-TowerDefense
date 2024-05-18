using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        // 게임 시작 시 Scene 매니저 초기화 후 TileScene 로드
        SceneManager.Instance.LoadTileScene();
        ScoreManager.Instance.AddScore(0);
    }
}
