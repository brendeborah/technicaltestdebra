using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject warrior; // Reference to the warrior enemy GameObject
    public GameObject archer; // Reference to the archer enemy GameObject
    public GameObject healer;

    void Start()
    {
        // Deactivate enemies at the start
        if (warrior != null)
        {
            warrior.SetActive(false);
        }
        if (archer != null)
        {
            archer.SetActive(false);
        }
        if (healer != null)
        {
            healer.SetActive(false);
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            SpawnEnemy(warrior);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            SpawnEnemy(archer);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SpawnEnemy(healer);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        if (enemy != null && !enemy.activeInHierarchy)
        {
            enemy.SetActive(true);
            Debug.Log($"{enemy.name} spawned at position: {enemy.transform.position}");
        }
        else if (enemy == null)
        {
            Debug.LogError("Enemy GameObject is not set.");
        }
        else
        {
            Debug.LogWarning($"{enemy.name} is already active.");
        }
    }
}
