using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TowerImageChange : MonoBehaviour
{
    public GameObject[] turretPrefabs; // 각 버튼에 대한 포탑 프리팹 배열
    public Button[] buttons; // 각 버튼 배열
    public int buttonIndex; // 버튼의 인덱스를 저장하는 변수
    public TowerImageChange turretController;
    private GameObject currentTurret; // 현재 포탑

    void Start()
    {
        currentTurret = Instantiate(turretPrefabs[0], transform.position, Quaternion.identity);

        // 각 버튼에 대해 클릭 이벤트를 추가합니다.
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // 클로저에서 사용할 변수를 별도로 설정합니다.
            buttons[i].onClick.AddListener(() => OnClick(index));
        }
    }
    void OnClick(int buttonIndex)
    {
        // 버튼이 클릭되었을 때 포탑 컨트롤러에게 버튼의 인덱스를 전달하여 포탑을 변경합니다.
        if (turretController != null)
        {
            turretController.ChangeTurret(buttonIndex);
        }
    }

    void ChangeTurret(int index)
    {
        // 현재 포탑이 존재하면 삭제합니다.
        if (currentTurret != null)
        {
            Destroy(currentTurret);
        }

        // 선택한 버튼에 해당하는 포탑을 생성합니다.
        if (index >= 0 && index < turretPrefabs.Length)
        {
            currentTurret = Instantiate(turretPrefabs[index], transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Invalid turret index!");
        }
    }

    private void FireProjectile(int buttonIndex)
    {
        if (currentTurret != null)
        {
            // 발사체를 발사하는 메서드에 버튼의 인덱스를 전달합니다.
            currentTurret.GetComponent<ButtonController>().FireProjectileCoroutine(buttonIndex);
        }
        else
        {
            Debug.LogError("No turret to fire projectiles!");
        }
    }
}
