using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyDestroyType { Kill = 0, Arrive }
public class Enemy : MonoBehaviour
{
    public int scoreValue = 10;

    private Transform playerTransform;
    private Movement2D movement2D;
    private EnemySpawner enemySpawner;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void Setup(EnemySpawner enemySpawner, Transform playerTransform)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;
        this.playerTransform = playerTransform;

        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        while (true)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            movement2D.MoveTo(direction);

            yield return null;
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        enemySpawner.DestroyEnemy(type, this, scoreValue);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            
        }
    }
}
