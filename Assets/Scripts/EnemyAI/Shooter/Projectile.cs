/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //public GameObject impactEffect;
    public float radius = 3;
    public int damageAmount = 15;

    private void OnCollisionEnter(Collision collision)
    {
        //GameObject impact =  Instantiate(impactEffect, transform.position, Quaternion.identity);
        //Destroy(impact, 2);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.tag == "Player")
            {
                PlayerManager.TakeDamage(damageAmount);
            }
        }
        Destroy(gameObject, 1);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float radius = 3;
    public int damageAmount = 15;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                PlayerManager.Instance.TakeDamage(damageAmount);
            }
        }
        Destroy(gameObject, 1);
    }
}




