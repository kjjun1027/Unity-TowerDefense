using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiole : MonoBehaviour
{
    public int damageAmount; // �߻�ü�� ������ ��
    public float speed = 10f; // �߻�ü�� �ӵ�

    private Rigidbody2D rb;
    private Transform target;
    private void Awake()
    {
        damageAmount = UnityEngine.Random.Range(10, 20);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed; // ������ �������� �߻�ü �̵�
    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        
            // ������ ������ �ֱ�
            enemy.TakeDamage(damageAmount);

            // �߻�ü �ı�
            Destroy(gameObject);
        
    }
 
}
