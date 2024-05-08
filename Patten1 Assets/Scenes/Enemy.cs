using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // 최대 체력
    public int currentHealth; // 현재 체력

    public Slider healthSlider; // 체력을 표시할 Slider
    public int scoreValue = 0;

    void Start()
    {
        currentHealth = maxHealth;

        // 체력 슬라이더의 최대값을 최대 체력으로 설정
        healthSlider.maxValue = maxHealth;
        // 현재 체력으로 초기화
        healthSlider.value = currentHealth;
    }

    // 데미지를 받는 메서드
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);

        // 체력 슬라이더 갱신
        healthSlider.value = currentHealth;
        scoreValue ++;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 사망 처리 메서드
    void Die()
    {
        ScoreManager.Instance.AddScore(scoreValue);
        currentHealth = 100;
        scoreValue = 0;
    }
}