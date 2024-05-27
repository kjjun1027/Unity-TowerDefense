using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using TMPro;
using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField]
    private float maxHP = 3;
    public float currentHP;
    public bool isDie = false;
    private bool isInvincible = false;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerAction action;
    public TextMeshProUGUI Hptext;

    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;

    private void Awake()
    {
        currentHP = maxHP;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        action = GetComponent<PlayerAction>();
    }
    public void Resetto()
    {
        currentHP = maxHP;
    }
    public void Update()
    {
        Hptext.text = "PlayerLife: "+ currentHP+ "/" + maxHP;
    }
    public void TakeDamage(float damage)
    {
        if (isDie || isInvincible) return;

        currentHP -= damage;

        if (currentHP <= 0)
        {
            isDie = true;
            OnDie();
        }
        else
        {
            StartCoroutine(DamageAnimation());
        }
    }

    private IEnumerator DamageAnimation()
    {
        isInvincible = true;
        animator.SetTrigger("Hit");

        // HitAlphaAnimation 코루틴 실행
        yield return StartCoroutine(HitAlphaAnimation());

        // 애니메이션의 지속 시간 동안 대기 (애니메이션 클립의 길이로 설정)
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

        isInvincible = false;
    }

    private IEnumerator HitAlphaAnimation()
    {
        Color color = spriteRenderer.color;

        for(int i = 0; i < 3; i++)
        {
            color.a = 0.4f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.05f);

            color.a = 1.0f;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void OnDie()
    {
        action.GameOver();
    }
}
