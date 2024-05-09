using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.UIElements;

public interface ITurretState
{
    void HandleClick(int buttonIndex);
    void HandleFire(int index);
    void ChangeAppearance(int index); // ���� ������ ���� �޼��� �߰�
}

public class NormalState : ITurretState
{
    private TowerImageChange turret;

    public NormalState(TowerImageChange turret)
    {
        this.turret = turret;
    }

    public void HandleClick(int buttonIndex)
    {
        turret.ChangeTurret(buttonIndex);
    }

    public void HandleFire(int index)
    {
        turret.FireProjectile(index);
    }

    public void ChangeAppearance(int index)
    {
        turret.ChangeAppearance(index);
    }
}

public class FireState : ITurretState
{
    private TowerImageChange turret;

    public FireState(TowerImageChange turret)
    {
        this.turret = turret;
    }

    public void HandleClick(int buttonIndex)
    {
        // �߻� �߿��� ��ư Ŭ���� ó������ ����
    }

    public void HandleFire()
    {
        // �̹� �߻� ���� �����̹Ƿ� ����
    }

    public void ChangeAppearance(int index)
    {
        // �߻� �߿��� ���� ������ ó������ ����
    }

    public void HandleFire(int index)
    {
        throw new NotImplementedException();
    }
}

public class TowerImageChange : MonoBehaviour
{
    private ITurretState currentState;
    public GameObject[] turretAppearances;
    public GameObject[] turretPrefabs;
    private GameObject currentTurret;
    void Start()
    {
        // ���� ������ �迭 �ʱ�ȭ
        turretAppearances = new GameObject[turretPrefabs.Length];
        for (int i = 0; i < turretPrefabs.Length; i++)
        {
            turretAppearances[i] = Instantiate(turretPrefabs[i], transform.position, Quaternion.identity);
            // ���� �� ��Ȱ��ȭ
            turretAppearances[i].SetActive(false);
        }

        // �ʱ� ��ž ����
        currentState = new NormalState(this);
        currentTurret = Instantiate(turretPrefabs[0], transform.position, Quaternion.identity);
    }

    public void OnClick(int buttonIndex)
    {
        currentState.HandleClick(buttonIndex);
    }

    public void ChangeTurret(int index)
    {
        Destroy(currentTurret);
        currentTurret = Instantiate(turretPrefabs[index], transform.position, Quaternion.identity);
    }

    public void FireProjectile(int index)
    {
        currentTurret.GetComponent<ButtonController>().FireProjectileCoroutine(index);
    }

    public void ChangeAppearance(int index)
    {
        Destroy(currentTurret);
        currentTurret = Instantiate(turretPrefabs[index], transform.position, Quaternion.identity);
    }

    public void SetState(ITurretState state)
    {
        currentState = state;
    }

    
}
