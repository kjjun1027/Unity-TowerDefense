using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100; // �ִ� ü��
    public int currentHealth; // ���� ü��

    public Slider healthSlider; // ü���� ǥ���� Slider
    public int scoreValue = 0;

    void Start()
    {
        currentHealth = maxHealth;

        // ü�� �����̴��� �ִ밪�� �ִ� ü������ ����
        healthSlider.maxValue = maxHealth;
        // ���� ü������ �ʱ�ȭ
        healthSlider.value = currentHealth;
    }

    // �������� �޴� �޼���
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Enemy Health: " + currentHealth);

        // ü�� �����̴� ����
        healthSlider.value = currentHealth;
        scoreValue ++;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ��� ó�� �޼���
    void Die()
    {
        ScoreManager.Instance.AddScore(scoreValue);
        currentHealth = 100;
        scoreValue = 0;
    }
}