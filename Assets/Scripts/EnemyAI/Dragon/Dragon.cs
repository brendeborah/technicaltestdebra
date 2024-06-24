/*using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public int HP = 1000;
    public Slider healthBar;
    public Animator animator;
    private bool isDead = false;

    private void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return; // Ignore damage if already dead

        HP -= damageAmount;
        if (HP <= 0)
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
        animator.SetTrigger("die");
        // Disable collider and other components if necessary
        GetComponent<Collider>().enabled = false;
        // Start coroutine to deactivate the GameObject
        StartCoroutine(DeactivateAfterAnimation());
    }

    private IEnumerator DeactivateAfterAnimation()
    {
        // Assuming the death animation is 2 seconds long. Adjust as needed.
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        // Optionally re-enable components for future use
        GetComponent<Collider>().enabled = true; // Re-enable collider if needed
        isDead = false;
        HP = 1000 ; // Reset HP if you want to
    }
}*/

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dragon : MonoBehaviour
{
    public int HP = 1000;
    public Slider healthBar;
    public Animator animator;
    private bool isDead = false;
    public int damageAmount = 10; // Damage dealt to the player on collision

    private void Update()
    {
        healthBar.value = HP;
    }

    public void TakeDamage(int damageAmount)
    {
        if (isDead) return; // Ignore damage if already dead

        HP -= damageAmount;
        if (HP <= 0)
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
        animator.SetTrigger("die");
        // Disable collider and other components if necessary
        GetComponent<Collider>().enabled = false;
        // Start coroutine to deactivate the GameObject
        StartCoroutine(DeactivateAfterAnimation());
    }

    private IEnumerator DeactivateAfterAnimation()
    {
        // Assuming the death animation is 2 seconds long. Adjust as needed.
        yield return new WaitForSeconds(2f);

        gameObject.SetActive(false);
        // Optionally re-enable components for future use
        GetComponent<Collider>().enabled = true; // Re-enable collider if needed
        isDead = false;
        HP = 1000; // Reset HP if you want to
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerManager.Instance.TakeDamage(damageAmount);
        }
    }
}

