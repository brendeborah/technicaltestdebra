using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    public int enemyHP = 1000;
    public Slider healthBar;
    public GameObject projectile;
    public Transform projectilePoint;
    public Animator animator;
    private bool isDead = false;

    private void Update()
    {
        healthBar.value = enemyHP;
    }

    void Start()
    {
        isDead = false;
        enemyHP = 1000; // Reset HP at the start
    }

    public void Shoot()
    {
        Rigidbody rb = Instantiate(projectile, projectilePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * 25f, ForceMode.Impulse);
        rb.AddForce(transform.up * 2, ForceMode.Impulse);
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return; // Ignore damage if already dead

        enemyHP -= damageAmount;
        if (enemyHP <= 0)
        {
            Die();
        }
        else
        {
            // Play damage animation
            animator.SetTrigger("damage");
        }
    }

    void Die()
    {
        isDead = true;
        // Play death animation
        animator.SetTrigger("death");
        GetComponent<CapsuleCollider>().enabled = false;

        // Schedule deactivation of the GameObject
        StartCoroutine(DeactivateAfterAnimation());
    }

    private IEnumerator DeactivateAfterAnimation()
    {
        // Assuming the death animation is 2 seconds long. Adjust as needed.
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        GetComponent<CapsuleCollider>().enabled = true; // Re-enable collider for future use
        isDead = false;
        enemyHP = 1000;
    }
}

