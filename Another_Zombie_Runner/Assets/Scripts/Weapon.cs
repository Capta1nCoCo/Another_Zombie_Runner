using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 60f;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    float weaponSwitchDelay = 0.75f;

    bool canShoot = true;

    private void OnEnable()
    {
        StartCoroutine(ShootDelay(weaponSwitchDelay));
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Shoot();            
        }
    }

    IEnumerator ShootDelay(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    //private void Shoot()
    //{
    //    if (ammoSlot.ReturnAmmo() > 0 && canShoot)
    //    {
    //        ammoSlot.ReduceAmmo();            
    //        PlayMuzzleFlash();
    //        ProcessRaycast();
    //        StartCoroutine(ShootDelay(timeBetweenShots));
    //    }
       
    //}

    private void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        var fx = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        fx.GetComponentInChildren<ParticleSystem>().Play();
        Destroy(fx, 0.1f);
    }
}
