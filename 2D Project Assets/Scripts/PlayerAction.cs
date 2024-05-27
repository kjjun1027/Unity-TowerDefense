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
    private PlayerHp playerHp;
    public int Resetnumber;

    private List<GameObject> deactivatedEnemies = new List<GameObject>();
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameEnding = FindObjectOfType<GameEnding>();
        playerHp = GetComponent<PlayerHp>();
    }

   
    void Update()
    {
        Resetnumber = 0;
        playerHp.isDie = false;
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        anim.SetBool("hstance", true);
        // 마우스 위치에 따른 방향 설정
        if (mousePosition.x < transform.position.x)
        {
            if (h != 0||v!=0)
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
                anim.SetInteger("hAxisRaw", -1);
                anim.SetBool("IsChage", true);
            }
        }
        else
        {
            if(h!=0||v!=0)
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
            else
            {
                anim.SetInteger("hAxisRaw", 1);
                anim.SetBool("IsChage", true);
            }
        }


    }
    private void FixedUpdate()
    {
        Vector2 moveVec = new Vector2(h, v).normalized;
        rigid.velocity = moveVec * Speed;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerHp.TakeDamage(1);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            playerHp.TakeDamage(1);
        }
    }

    public void GameOver()
    {
        Resetnumber = 1;
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
