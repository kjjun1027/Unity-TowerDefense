using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewCamera : MonoBehaviour
{
    public Transform target;

    // ĳ���Ϳ� ī�޶� ������ �Ÿ�
    public Vector3 offset;

    // ī�޶� ���󰡾� �ϴ��� ���θ� �����ϴ� �÷���
    private bool shouldFollow = false;

    void Update()
    {
        if (shouldFollow)
        {
            // ī�޶��� ��ġ�� ĳ������ ��ġ�� offset��ŭ ���� ������ �̵�
            transform.position = target.position + offset;

            // ī�޶� ĳ���͸� �ٶ󺸵��� ȸ��
            transform.LookAt(target);
        }
    }

    // Ư�� �Լ����� ȣ��Ǿ�� �� �Լ�
    public void StartFollowing()
    {
        shouldFollow = true;
    }
}
