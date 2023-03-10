using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{
    private bool IsActive = true;
    public GameObject markPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (!IsActive) return;
        IsActive = false;

        GetComponent<Rigidbody>().useGravity = true;

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            Vector3 position = collision.contacts[0].point;
            Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            Instantiate(markPrefab, position, rotation);

            Destroy(transform, 0.1f);

            enemy.OnHit();
        }

        
    }
}
