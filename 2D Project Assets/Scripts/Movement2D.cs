using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement2D : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.0f;
    [SerializeField]
    private Vector3 moveDirection = Vector3.zero;
    private float baseMoveSpeed;
    private Vector3 targetPosition; // 목표 위치 저장 변수

    public float MoveSpeed
    {
        set
        {
            moveSpeed = Mathf.Max(0, value);
            baseMoveSpeed = moveSpeed;
        }
        get => moveSpeed;
    }

    private void Update()
    {
        Move(); // 이동 메서드 호출
    }

    private void Move()
    {
        // 현재 방향으로 이동
        transform.position += moveDirection * moveSpeed * Time.deltaTime;    
    }

    public void MoveTo(Vector3 direction)
    {
        moveDirection = direction;
    }

    public void ResetMoveSpeed()
    {
        moveSpeed = baseMoveSpeed;
    }

    private void Awake()
    {
        baseMoveSpeed = moveSpeed;
    }
}
