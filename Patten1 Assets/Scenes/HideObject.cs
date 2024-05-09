using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트를 비활성화합니다.
        gameObject.SetActive(false);
    }
}
