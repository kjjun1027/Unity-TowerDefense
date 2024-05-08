using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject projectilePrefab; // 발사체 프리팹
    public Transform firePoint; // 발사 위치
    public Button fireButton; // 발사 버튼

    private bool canFire = true; // 발사 가능한지 여부를 나타내는 변수

    void Start()
    {
        // 발사 버튼에 클릭 이벤트 추가
        fireButton.onClick.AddListener(OnFireButtonClick);
    }

    // 발사 버튼 클릭 이벤트 핸들러
    void OnFireButtonClick()
    {
        if (canFire)
        {
            // 발사 가능한 경우 발사체 발사 코루틴 시작
            StartCoroutine(FireProjectileCoroutine());
        }
    }

    // 발사체 발사 코루틴
    IEnumerator FireProjectileCoroutine()
    {
        canFire = false; // 발사 중복 방지

        // 발사체 생성
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // 1초 대기
        yield return new WaitForSeconds(0);

        canFire = true; // 발사 가능 상태로 변경
    }
}
