using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class TowerImageChange : MonoBehaviour
{
    public GameObject[] turretPrefabs; // �� ��ư�� ���� ��ž ������ �迭
    public Button[] buttons; // �� ��ư �迭
    public int buttonIndex; // ��ư�� �ε����� �����ϴ� ����
    public TowerImageChange turretController;
    private GameObject currentTurret; // ���� ��ž

    void Start()
    {
        currentTurret = Instantiate(turretPrefabs[0], transform.position, Quaternion.identity);

        // �� ��ư�� ���� Ŭ�� �̺�Ʈ�� �߰��մϴ�.
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Ŭ�������� ����� ������ ������ �����մϴ�.
            buttons[i].onClick.AddListener(() => OnClick(index));
        }
    }
    void OnClick(int buttonIndex)
    {
        // ��ư�� Ŭ���Ǿ��� �� ��ž ��Ʈ�ѷ����� ��ư�� �ε����� �����Ͽ� ��ž�� �����մϴ�.
        if (turretController != null)
        {
            turretController.ChangeTurret(buttonIndex);
        }
    }

    void ChangeTurret(int index)
    {
        // ���� ��ž�� �����ϸ� �����մϴ�.
        if (currentTurret != null)
        {
            Destroy(currentTurret);
        }

        // ������ ��ư�� �ش��ϴ� ��ž�� �����մϴ�.
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
            // �߻�ü�� �߻��ϴ� �޼��忡 ��ư�� �ε����� �����մϴ�.
            currentTurret.GetComponent<ButtonController>().FireProjectileCoroutine(buttonIndex);
        }
        else
        {
            Debug.LogError("No turret to fire projectiles!");
        }
    }
}
