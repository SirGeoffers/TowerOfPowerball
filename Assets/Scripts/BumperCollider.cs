using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCollider : MonoBehaviour
{
    public Bumper parent;

    private void OnCollisionEnter(Collision collision)
    {
        parent.OnCollisionEnter(collision);
    }
}
