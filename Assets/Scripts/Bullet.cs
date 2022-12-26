using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 5f;
    private bool IsActive = true;
    public GameObject markPrefab;
    private GameManager Manager;
    
    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

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
            GameObject newToy = Instantiate(markPrefab, position, rotation);

            Manager.createToyList.Add(newToy);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
