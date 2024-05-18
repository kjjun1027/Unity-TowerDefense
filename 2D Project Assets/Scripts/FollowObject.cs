using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // ĳ����(Transform)�� ����Ű�� ����
    public float horizontalSmoothSpeed = 5.5f; // �¿� �̵��� ���� �ε巯�� �̵� �ӵ�
    public float verticalSmoothSpeed = 2f; // ���� �̵��� ���� �ε巯�� �̵� �ӵ�
    public float xOffset = 0.55f; // �¿� �̵��� ����� ������ ��
    public float yOffset = 0.2f; // ���� �̵��� ����� ������ ��
    public Transform childObject; // �ڽ� ������Ʈ�� ����Ű�� ����

    private Vector3 initialChildOffset; // �ڽ� ������Ʈ�� �ʱ� ������

    void Start()
    {
        // �ڽ� ������Ʈ�� �ʱ� �������� ���
        if (childObject != null)
        {
            initialChildOffset = childObject.position - transform.position;
        }
    }

    void Update()
    {
        if (target != null) // Ÿ���� �����ϴ� ��쿡�� ����
        {
            // ���콺 ��ġ�� ȭ�� ��ǥ�� ��ȯ
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // ���콺 ��ġ�� z ��ǥ�� 0���� ���� (2D ȯ�� ����)

            // ��ǥ ��ġ ���
            Vector3 targetPosition = target.position;

            // �¿� �̵� ó��
            if (mousePosition.x < target.position.x)
            {
                targetPosition.x = target.position.x - xOffset;
            }
            else if (mousePosition.x > target.position.x)
            {
                targetPosition.x = target.position.x + xOffset;
            }

            // ���� �̵� ó��
            if (mousePosition.y < target.position.y)
            {
                targetPosition.y = target.position.y - yOffset;
            }
            else if (mousePosition.y > target.position.y)
            {
                targetPosition.y = target.position.y + yOffset;
            }

            // �ε巯�� �̵��� ���� ���� ��ġ���� ��ǥ ��ġ������ ���� ���
            Vector3 smoothedPosition = new Vector3(
                Mathf.Lerp(transform.position.x, targetPosition.x, horizontalSmoothSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.y, targetPosition.y, verticalSmoothSpeed * Time.deltaTime),
                transform.position.z
            );

            // ������Ʈ�� ��ġ�� ������ ��ġ�� ����
            transform.position = smoothedPosition;

            // �ڽ� ������Ʈ�� ��ġ�� �θ� ������Ʈ�� ���ο� ��ġ�� �������� ����
            if (childObject != null)
            {
                childObject.position = transform.position + initialChildOffset;
            }

            // ������Ʈ ȸ�� ����
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
