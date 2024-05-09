using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public GameObject[] turretPrefabs;
    public Button[] buttonHandlers;
    public GameObject projectilePrefab; // 발사체 프리팹
    public Transform[] firePoints; // 발사 위치 배열

    private GameObject currentTurret;
    private bool canFire = true;  // 발사 가능한지 여부를 나타내는 변수

    void Start()
    {
        // 발사 버튼에 클릭 이벤트 추가
        for (int i = 0; i < buttonHandlers.Length; i++)
        {
            int index = i;
            buttonHandlers[i].GetComponent<Button>().onClick.AddListener(() => OnFireButtonClick(index));
        }
    }

    // 발사 버튼 클릭 이벤트 핸들러
    void OnFireButtonClick(int buttonIndex)
    {
        if (canFire)
        {
            // 발사 가능한 경우 발사체 발사 코루틴 시작
            StartCoroutine(FireProjectileCoroutine(buttonIndex));
        }
    }

    // 발사체 발사 코루틴
    public IEnumerator FireProjectileCoroutine(int buttonIndex)
    {
        canFire = false; // 발사 중복 방지

        // 발사체 위치에 따라 발사
        if (buttonIndex >= 0 && buttonIndex < firePoints.Length)
        {
            // 발사체 생성
            Instantiate(projectilePrefab, firePoints[buttonIndex].position, firePoints[buttonIndex].rotation);

            Debug.Log($"Fired projectile from fire point {buttonIndex}!");
        }
        else
        {
            Debug.LogError("Invalid button index!");
        }

        // 1초 대기
        yield return new WaitForSeconds(0);

        canFire = true; // 발사 가능 상태로 변경
    }
}

