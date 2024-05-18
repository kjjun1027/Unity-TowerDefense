using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolloewCamera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private bool shouldFollow = false;

    void Update()
    {
        if (shouldFollow)
        {
            transform.position = target.position + offset;
            transform.LookAt(target);
        }
    }

    public void StartFollowing()
    {
        shouldFollow = true;
    }
}
