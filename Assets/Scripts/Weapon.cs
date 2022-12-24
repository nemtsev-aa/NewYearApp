using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Camera mainCamera;
    
    public float shootForce;
    public float spread;
    private GameObject selectionBullet;

    public void Shoot()
    {
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        Vector3 dirWithoutSpread = targetPoint - transform.position;

        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        Vector3 dirWithSpread = dirWithoutSpread + new Vector3(x, y, 0);
        selectionBullet = bullet;

        GameObject currentBullet = Instantiate(selectionBullet, transform.position, Quaternion.identity);
        

        //currentBullet.transform.forward = dirWithSpread.normalized;

        //currentBullet.GetComponent<Rigidbody>().AddForce(dirWithSpread.normalized * shootForce, ForceMode.Impulse);

        //Destroy(currentBullet, 2f);
    } 
}
