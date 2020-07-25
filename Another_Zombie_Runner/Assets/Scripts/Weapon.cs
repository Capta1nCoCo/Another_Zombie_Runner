using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 60f;
    [SerializeField] float timeBetweenShots = 1f;
    [SerializeField] float weaponSwitchDelay = 0.75f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] TextMeshProUGUI ammoText;
       
    bool canShoot = true;

    private void OnEnable()
    {
        StartCoroutine(ShootDelay(weaponSwitchDelay));
    }

    void Update()
    {
        DisplayAmmo();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();            
        }
    }

    private void DisplayAmmo()
    {        
        ammoText.text = ammoSlot.GetCurrentAmmo(ammoType).ToString();
    }

    IEnumerator ShootDelay(float delay)
    {
        canShoot = false;
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }

    private void Shoot()
    {
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0 && canShoot)
        {
            ammoSlot.ReduceAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
            StartCoroutine(ShootDelay(timeBetweenShots));
        }

    }

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
