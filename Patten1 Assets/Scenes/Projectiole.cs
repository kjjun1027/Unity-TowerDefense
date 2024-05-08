using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiole : MonoBehaviour
{
    public int damageAmount; // 발사체의 데미지 양
    public float speed = 10f; // 발사체의 속도

    private Rigidbody2D rb;
    private Transform target;
    private void Awake()
    {
        damageAmount = UnityEngine.Random.Range(10, 20);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // 오른쪽 방향으로 발사체 이동
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
            // 적에게 데미지 주기
            enemy.TakeDamage(damageAmount);

            // 발사체 파괴
            Destroy(gameObject);
        
    }
 
}
