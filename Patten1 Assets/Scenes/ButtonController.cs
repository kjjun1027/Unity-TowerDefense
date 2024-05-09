using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] turretPrefabs;
    public Button[] buttonHandlers;
    public GameObject projectilePrefab; // �߻�ü ������
    public Transform[] firePoints; // �߻� ��ġ �迭

    private GameObject currentTurret;
    private bool canFire = true;  // �߻� �������� ���θ� ��Ÿ���� ����

    void Start()
    {
        // �߻� ��ư�� Ŭ�� �̺�Ʈ �߰�
        for (int i = 0; i < buttonHandlers.Length; i++)
        {
            int index = i;
            buttonHandlers[i].GetComponent<Button>().onClick.AddListener(() => OnFireButtonClick(index));
        }
    }

    // �߻� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    void OnFireButtonClick(int buttonIndex)
    {
        if (canFire)
        {
            // �߻� ������ ��� �߻�ü �߻� �ڷ�ƾ ����
            StartCoroutine(FireProjectileCoroutine(buttonIndex));
        }
    }

    // �߻�ü �߻� �ڷ�ƾ
    public IEnumerator FireProjectileCoroutine(int buttonIndex)
    {
        canFire = false; // �߻� �ߺ� ����

        // �߻�ü ��ġ�� ���� �߻�
        if (buttonIndex >= 0 && buttonIndex < firePoints.Length)
        {
            // �߻�ü ����
            Instantiate(projectilePrefab, firePoints[buttonIndex].position, firePoints[buttonIndex].rotation);

            Debug.Log($"Fired projectile from fire point {buttonIndex}!");
        }
        else
        {
            Debug.LogError("Invalid button index!");
        }

        // 1�� ���
        yield return new WaitForSeconds(0);

        canFire = true; // �߻� ���� ���·� ����
    }
}

