using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void OnHit()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(Vector3.up * 800f);
        rigidbody.AddTorque(1000f, 0f, 0f);
    }
}
