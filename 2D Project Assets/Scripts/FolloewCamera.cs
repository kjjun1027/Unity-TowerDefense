using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewCamera : MonoBehaviour
{
    public Transform target;

    // 캐릭터와 카메라 사이의 거리
    public Vector3 offset;

    // 카메라를 따라가야 하는지 여부를 결정하는 플래그
    private bool shouldFollow = false;

    void Update()
    {
        if (shouldFollow)
        {
            // 카메라의 위치를 캐릭터의 위치에 offset만큼 더한 곳으로 이동
            transform.position = target.position + offset;

            // 카메라가 캐릭터를 바라보도록 회전
            transform.LookAt(target);
        }
    }

    // 특정 함수에서 호출되어야 할 함수
    public void StartFollowing()
    {
        shouldFollow = true;
    }
}
