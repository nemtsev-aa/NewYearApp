using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3f;
    public GameObject markPrefab;
    public GameObject EffectPrefab;

    private GameManager Manager;
    private Transform startPositionPrefab;

    private void Start()
    {
        Manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //GetComponent<Rigidbody>().useGravity = true;

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            Vector3 position = collision.contacts[0].point;
            Quaternion rotation = Quaternion.LookRotation(collision.contacts[0].normal);
            GameObject newToy = Instantiate(markPrefab, position, rotation);
            Instantiate(EffectPrefab, transform.position, transform.rotation);
            newToy.transform.GetComponent<AudioSource>().Play();

            //замораживаем снаряд
            Destroy(newToy.GetComponent<Rigidbody>());
            Manager.AddToyToCollection(newToy);

            //Destroy(gameObject); 
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }
}
