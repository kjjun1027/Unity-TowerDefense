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
    private Vector3 targetPosition;

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
        Move();
    }

    private void Move()
    {
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
