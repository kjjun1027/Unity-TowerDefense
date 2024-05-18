using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    Rigidbody2D rigid;
    float h;
    float v;
    Animator anim;
    public GameObject GameScene;
    public GameObject OverScene;
    private GameEnding GameEnding;

    private List<GameObject> deactivatedEnemies = new List<GameObject>();
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameEnding = FindObjectOfType<GameEnding>();

    }

   
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition.x < transform.position.x)
        {
            if (anim.GetInteger("hAxisRaw") != -1)
            {
                anim.SetBool("IsChage", true);
                anim.SetInteger("hAxisRaw", -1);
            }
            else
            {
                anim.SetBool("IsChage", false);
            }
        }
        else
        {
            if (anim.GetInteger("hAxisRaw") != 1)
            {
                anim.SetBool("IsChage", true);
                anim.SetInteger("hAxisRaw", 1);
            }
            else
            {
                anim.SetBool("IsChage", false);
            }
        }
    }
    private void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(h, v).normalized; // 입력 벡터를 정규화하여 대각선 이동을 가능하게 함
        rigid.velocity = moveVec * Speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameOver();
        }
    }

    public void GameOver()
    {      
        DestroyAllEnemies();
        Debug.Log("Game Over!");
        GameEnding.GameOver();  
        GameScene.SetActive(false);
        OverScene.SetActive(true);
        SceneManager.Instance.LoadOverScene();
    }
    public void GameClear()
    {
        Debug.Log("Game Clear!");
        GameEnding.GameClear();
        GameScene.SetActive(false);
        OverScene.SetActive(true);
        SceneManager.Instance.LoadOverScene();
    }
    public void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
