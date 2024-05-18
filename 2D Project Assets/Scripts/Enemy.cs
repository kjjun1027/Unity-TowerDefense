using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }
public class Enemy : MonoBehaviour
{
    public int scoreValue = 10; // 이 적이 죽을 때 추가될 점수

    private Transform playerTransform; // 플레이어의 Transform
    private Movement2D movement2D; // 이동을 담당하는 Movement2D 컴포넌트
    private EnemySpawner enemySpawner; // 적 스포너

    // Setup 메서드를 수정하여 플레이어 Transform을 받아오도록 합니다.
    public void Setup(EnemySpawner enemySpawner, Transform playerTransform)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;
        this.playerTransform = playerTransform;

        StartCoroutine("OnMove");
    }

    // 플레이어를 향해 이동하는 코루틴
    private IEnumerator OnMove()
    {
        while (true)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            movement2D.MoveTo(direction);

            yield return null;
        }
    }

    // 적이 죽을 때 호출되는 메서드
    public void OnDie(EnemyDestroyType type)
    {
        enemySpawner.DestroyEnemy(type, this, scoreValue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            // Ignore collision with objects tagged as "Wall"
            Physics2D.IgnoreCollision(other, GetComponent<Collider2D>());
        }
    }
}
