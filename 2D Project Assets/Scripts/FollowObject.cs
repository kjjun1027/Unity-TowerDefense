using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target; // 캐릭터(Transform)를 가리키는 변수
    public float horizontalSmoothSpeed = 5.5f; // 좌우 이동을 위한 부드러운 이동 속도
    public float verticalSmoothSpeed = 2f; // 상하 이동을 위한 부드러운 이동 속도
    public float xOffset = 0.55f; // 좌우 이동에 사용할 오프셋 값
    public float yOffset = 0.2f; // 상하 이동에 사용할 오프셋 값
    public Transform childObject; // 자식 오브젝트를 가리키는 변수

    private Vector3 initialChildOffset; // 자식 오브젝트의 초기 오프셋

    void Start()
    {
        // 자식 오브젝트의 초기 오프셋을 계산
        if (childObject != null)
        {
            initialChildOffset = childObject.position - transform.position;
        }
    }

    void Update()
    {
        if (target != null) // 타겟이 존재하는 경우에만 실행
        {
            // 마우스 위치를 화면 좌표로 변환
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // 마우스 위치의 z 좌표를 0으로 설정 (2D 환경 가정)

            // 목표 위치 계산
            Vector3 targetPosition = target.position;

            // 좌우 이동 처리
            if (mousePosition.x < target.position.x)
            {
                targetPosition.x = target.position.x - xOffset;
            }
            else if (mousePosition.x > target.position.x)
            {
                targetPosition.x = target.position.x + xOffset;
            }

            // 상하 이동 처리
            if (mousePosition.y < target.position.y)
            {
                targetPosition.y = target.position.y - yOffset;
            }
            else if (mousePosition.y > target.position.y)
            {
                targetPosition.y = target.position.y + yOffset;
            }

            // 부드러운 이동을 위해 현재 위치에서 목표 위치까지의 보간 계산
            Vector3 smoothedPosition = new Vector3(
                Mathf.Lerp(transform.position.x, targetPosition.x, horizontalSmoothSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.y, targetPosition.y, verticalSmoothSpeed * Time.deltaTime),
                transform.position.z
            );

            // 오브젝트의 위치를 보간된 위치로 설정
            transform.position = smoothedPosition;

            // 자식 오브젝트의 위치를 부모 오브젝트의 새로운 위치를 기준으로 조정
            if (childObject != null)
            {
                childObject.position = transform.position + initialChildOffset;
            }

            // 오브젝트 회전 설정
            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
