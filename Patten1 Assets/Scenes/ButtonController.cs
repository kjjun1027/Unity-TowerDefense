using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject projectilePrefab; // �߻�ü ������
    public Transform firePoint; // �߻� ��ġ
    public Button fireButton; // �߻� ��ư

    private bool canFire = true; // �߻� �������� ���θ� ��Ÿ���� ����

    void Start()
    {
        // �߻� ��ư�� Ŭ�� �̺�Ʈ �߰�
        fireButton.onClick.AddListener(OnFireButtonClick);
    }

    // �߻� ��ư Ŭ�� �̺�Ʈ �ڵ鷯
    void OnFireButtonClick()
    {
        if (canFire)
        {
            // �߻� ������ ��� �߻�ü �߻� �ڷ�ƾ ����
            StartCoroutine(FireProjectileCoroutine());
        }
    }

    // �߻�ü �߻� �ڷ�ƾ
    IEnumerator FireProjectileCoroutine()
    {
        canFire = false; // �߻� �ߺ� ����

        // �߻�ü ����
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // 1�� ���
        yield return new WaitForSeconds(0);

        canFire = true; // �߻� ���� ���·� ����
    }
}
