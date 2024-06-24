using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public Transform fpsCam;
    public float range = 20;
    public float impactForce = 150;
    public int damageAmount = 20;

    public int fireRate = 10;
    private float nextTimeToFire = 0f;

    public ParticleSystem muzzleFlush;
    public GameObject impactEffect;

    InputAction shoot;

    // Start is called before the first frame update
    void Start()
    {
        shoot = new InputAction("Shoot", binding: "<mouse>/leftButton");

        shoot.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        bool isShooting = shoot.ReadValue<float>() == 1;

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Fire();
        }
    }

    private void Fire()
    {
        RaycastHit hit;
        muzzleFlush.Play();
        if (Physics.Raycast(fpsCam.position, fpsCam.forward, out hit, range))
        {
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            Shooter e = hit.transform.GetComponent<Shooter>();
            if (e != null)
            {
                e.TakeDamage(damageAmount);
                return;
            }

            Dragon d = hit.transform.GetComponent<Dragon>();
            if (d != null)
            {
                d.TakeDamage(damageAmount);
                return;
            }
              

            Quaternion impactRotation = Quaternion.LookRotation(hit.normal);
            GameObject impact =  Instantiate(impactEffect, hit.point, impactRotation);
            Destroy(impact, 5);
        }
    }
}
