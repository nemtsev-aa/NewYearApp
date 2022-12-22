using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatus : MonoBehaviour
{
    [SerializeField] GameObject bulletCreator;

    private Weapon _weapon;

    private void Start()
    {
        _weapon = bulletCreator.GetComponent<Weapon>();
    }
    public void StartShothing(bool status)
    {
       _weapon.enabled = status;

    }
}
