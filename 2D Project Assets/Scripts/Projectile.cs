using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    private Movement2D movement2D;
    private Vector3 targetPosition;
    private float targetReachedThreshold = 0.1f;
    private float damage=1;

    public void Setup(Vector3 targetPosition)
    {
        movement2D = GetComponent<Movement2D>();
        this.targetPosition = targetPosition;
    }

    private void Update()
    {
        if (targetPosition != null)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            movement2D.MoveTo(direction);
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            // 거리가 임계값보다 작으면 목표에 도달한 것으로 간주합니다.
            if (distanceToTarget <= targetReachedThreshold)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player")) return;
        if (collision.CompareTag("Wall"))
        {           
                Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHP>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
