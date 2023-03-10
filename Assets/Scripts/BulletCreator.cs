using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCreator : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float BulletVelocity = 20f;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody>().velocity = transform.forward * BulletVelocity;
            
            Destroy(newBullet, 5f);
        }
    }

}
