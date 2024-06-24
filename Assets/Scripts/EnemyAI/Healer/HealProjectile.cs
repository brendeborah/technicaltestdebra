/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealProjectile : MonoBehaviour
{
    public float radius = 3;
    public int healAmount = 20;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                PlayerManager.TakeHeal(healAmount); // Call TakeHeal instead of TakeDamage
            }
        }
        Destroy(gameObject, 1);
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealProjectile : MonoBehaviour
{
    public float radius = 3;
    public int healAmount = 20;

    private void OnCollisionEnter(Collision collision)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Player"))
            {
                PlayerManager.Instance.TakeHeal(healAmount);
            }
        }
        Destroy(gameObject, 1);
    }
}



