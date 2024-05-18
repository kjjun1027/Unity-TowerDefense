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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SpawnProjectile();
        }
    }
    private void SpawnProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 spawnPosition;
        if (mousePosition.x < transform.position.x)
        {
            spawnPosition = spawnPoint.position - new Vector3(0.55f, 0, 0); // 0.4 단위로 좌측으로 이동
        }
        else
        {
            spawnPosition = spawnPoint.position + new Vector3(0, 0, 0); // 0.4 단위로 우측으로 이동
        }

        GameObject clone = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(mousePosition);
    }
}
