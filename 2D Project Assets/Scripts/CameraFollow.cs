using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerTransform;
    public Vector3 offset;

    public void SetPlayer(Transform player)
    {
        playerTransform = player;
    }

    public void FollowPlayer()
    {
        if (playerTransform == null)
        {
            Debug.LogError("Player Transform is not set!");
            return;
        }
        Vector3 newPosition = playerTransform.position + offset;
        newPosition.z = transform.position.z; 
        transform.position = newPosition;
    }
}
