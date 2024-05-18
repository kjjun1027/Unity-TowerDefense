using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    private void Start()
    {
        // ���� ���� �� Scene �Ŵ��� �ʱ�ȭ �� TileScene �ε�
        SceneManager.Instance.LoadTileScene();
        ScoreManager.Instance.AddScore(0);
    }
}
