using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float impulseStrength = 10.0f;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 impulseDirection = (otherRigidbody.transform.position - this.transform.position).normalized;
        Vector3 impulse = impulseDirection * impulseStrength;
        otherRigidbody.AddForce(impulse, ForceMode.Impulse);

        animator.SetTrigger("Bump");
    }
}
