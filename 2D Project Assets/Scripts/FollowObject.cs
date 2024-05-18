using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform target;
    public float horizontalSmoothSpeed = 5.5f;
    public float verticalSmoothSpeed = 2f;
    public float xOffset = 0.55f;
    public float yOffset = 0.2f; 
    public Transform childObject;

    private Vector3 initialChildOffset;

    void Start()
    {
        if (childObject != null)
        {
            initialChildOffset = childObject.position - transform.position;
        }
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 targetPosition = target.position;
            if (mousePosition.x < target.position.x)
            {
                targetPosition.x = target.position.x - xOffset;
            }
            else if (mousePosition.x > target.position.x)
            {
                targetPosition.x = target.position.x + xOffset;
            }

            if (mousePosition.y < target.position.y)
            {
                targetPosition.y = target.position.y - yOffset;
            }
            else if (mousePosition.y > target.position.y)
            {
                targetPosition.y = target.position.y + yOffset;
            }

            Vector3 smoothedPosition = new Vector3(
                Mathf.Lerp(transform.position.x, targetPosition.x, horizontalSmoothSpeed * Time.deltaTime),
                Mathf.Lerp(transform.position.y, targetPosition.y, verticalSmoothSpeed * Time.deltaTime),
                transform.position.z
            );

            transform.position = smoothedPosition;

            if (childObject != null)
            {
                childObject.position = transform.position + initialChildOffset;
            }

            Vector3 direction = mousePosition - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
    }
}
