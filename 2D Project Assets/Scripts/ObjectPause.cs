using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPause : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 savedVelocity;
    private Vector3 savedAngularVelocity;
    private bool isPaused = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void PauseObject()
    {
        if (!isPaused)
        {
            savedVelocity = rb.velocity;
            savedAngularVelocity = rb.angularVelocity;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            isPaused = true;
        }
    }

    public void ResumeObject()
    {
        if (isPaused)
        {
            rb.isKinematic = false;
            rb.velocity = savedVelocity;
            rb.angularVelocity = savedAngularVelocity;
            isPaused = false;
        }
    }
}
