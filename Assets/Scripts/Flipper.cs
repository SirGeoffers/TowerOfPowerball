using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public float maxRotationOffset = -30;
    public float timeToMaxRotation = 0.1f;
    public bool isLeft = true;

    new private Rigidbody rigidbody = null;
    private Vector3 initialRotation;
    private bool isActive = false;
    private float t = 0;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        initialRotation = this.transform.eulerAngles;
    }

    void Update()
    {
        isActive = isLeft ? Input.GetButton("Left") : Input.GetButton("Right");
    }

    private void FixedUpdate()
    {
        t += (1.0f / timeToMaxRotation) * Time.fixedDeltaTime * (isActive ? 1 : -1);
        t = Mathf.Clamp01(t);

        Vector3 targetRotation = initialRotation;
        targetRotation.y = initialRotation.y + (t * maxRotationOffset);
        rigidbody.MoveRotation(Quaternion.Euler(targetRotation));
    }
}
