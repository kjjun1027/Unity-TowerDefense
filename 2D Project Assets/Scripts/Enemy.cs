using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }
public class Enemy : MonoBehaviour
{
    public int scoreValue = 10; // �� ���� ���� �� �߰��� ����

    private Transform playerTransform; // �÷��̾��� Transform
    private Movement2D movement2D; // �̵��� ����ϴ� Movement2D ������Ʈ
    private EnemySpawner enemySpawner; // �� ������

    // Setup �޼��带 �����Ͽ� �÷��̾� Transform�� �޾ƿ����� �մϴ�.
    public void Setup(EnemySpawner enemySpawner, Transform playerTransform)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;
        this.playerTransform = playerTransform;

        StartCoroutine("OnMove");
    }

    // �÷��̾ ���� �̵��ϴ� �ڷ�ƾ
    private IEnumerator OnMove()
    {
        while (true)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            movement2D.MoveTo(direction);

            yield return null;
        }
    }

    // ���� ���� �� ȣ��Ǵ� �޼���
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
