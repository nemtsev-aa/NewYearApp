using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 5f;
    public GameObject markPrefab;
    public GameObject EffectPrefab;

    private GameManager Manager;
    private bool IsActive = true;
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

            //замораживаем снаряд
            Destroy(newToy.GetComponent<Rigidbody>());
            Manager.createToyList.Add(newToy);
            Destroy(gameObject);
            Instantiate(EffectPrefab, transform.position, transform.rotation);

        }
        else
        {
            Destroy(gameObject);
        }
    }
}
