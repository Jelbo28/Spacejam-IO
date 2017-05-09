using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.Collections;

public class Health : NetworkBehaviour
{
    [SerializeField]
    private GameObject gameOver;
    public const int maxHealth = 100;

    [SyncVar]
    public int currentHealth = maxHealth;
    private RectTransform healthBar;


    void Start()
    {
        gameOver = FindObjectOfType<Canvas>().transform.GetChild(1).gameObject;
            healthBar = FindObjectOfType<Canvas>().transform.GetChild(0).GetChild(0).GetComponentInChildren<RectTransform>();
    }

    public void TakeDamage(int amount)
    {
        if (!isServer)
        {
            return;
        }

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if (isLocalPlayer)
                gameOver.SetActive(true);
            //Debug.Log("Dead!");
        }
    }

    void OnChangeHealth(int health)
    {
        healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}