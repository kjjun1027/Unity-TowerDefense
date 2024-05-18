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
        // 마우스 왼쪽 버튼이 눌렸을 때 발사
        if (Input.GetMouseButtonDown(0))
        {
            SpawnProjectile();
        }
    }
    private void SpawnProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // z 축 값을 명시적으로 0으로 설정

        // spawnPoint의 위치를 기준으로 마우스의 좌우 위치에 따라 spawnPosition을 설정
        Vector3 spawnPosition;
        if (mousePosition.x < transform.position.x)
        {
            // 마우스가 캐릭터의 좌측에 있을 때
            spawnPosition = spawnPoint.position - new Vector3(0.55f, 0, 0); // 0.4 단위로 좌측으로 이동
        }
        else
        {
            // 마우스가 캐릭터의 우측에 있을 때
            spawnPosition = spawnPoint.position + new Vector3(0, 0, 0); // 0.4 단위로 우측으로 이동
        }

        GameObject clone = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
        clone.GetComponent<Projectile>().Setup(mousePosition);
    }
}
