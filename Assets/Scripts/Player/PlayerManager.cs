/*using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static int playerHP = 1000;
    public static int maxPlayerHP = 1500;
    public TextMeshProUGUI playerHPText;
    public static bool isGameOver;

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public static void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            isGameOver = true;
        }
    }

    public static void TakeHeal(int healAmount)
    {
        playerHP += healAmount;
        if (playerHP > maxPlayerHP)
        {
            playerHP = maxPlayerHP;
        }
    }
}*/

using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }
    public int playerHP = 1000;
    public int maxPlayerHP = 1500;
    public TextMeshProUGUI playerHPText;
    public bool isGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        isGameOver = false;
    }

    void Update()
    {
        playerHPText.text = "+" + playerHP;
        if (isGameOver)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void TakeDamage(int damageAmount)
    {
        playerHP -= damageAmount;
        if (playerHP <= 0)
        {
            isGameOver = true;
        }
    }

    public void TakeHeal(int healAmount)
    {
        playerHP += healAmount;
        if (playerHP > maxPlayerHP)
        {
            playerHP = maxPlayerHP;
        }
    }
}

