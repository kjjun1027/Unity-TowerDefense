using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    [SerializeField]
    private Transform spawnPoint;

    private Transform attackTarget = null;
    // Start is called before the first frame update
    private void Update()
    {
        // ���콺 ���� ��ư�� ������ �� �߻�
        if (Input.GetMouseButtonDown(0))
        {
            SpawnProjectile();
        }
    }
    private void SpawnProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // z �� ���� ��������� 0���� ����

        // spawnPoint�� ��ġ�� �������� ���콺�� �¿� ��ġ�� ���� spawnPosition�� ����
        Vector3 spawnPosition;
        if (mousePosition.x < transform.position.x)
        {
            // ���콺�� ĳ������ ������ ���� ��
            spawnPosition = spawnPoint.position - new Vector3(0.55f, 0, 0); // 0.4 ������ �������� �̵�
        }
        else
        {
            // ���콺�� ĳ������ ������ ���� ��
            spawnPosition = spawnPoint.position + new Vector3(0, 0, 0); // 0.4 ������ �������� �̵�
        }

        GameObject clone = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(mousePosition);
    }
}
