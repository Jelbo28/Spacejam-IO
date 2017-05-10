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
    private GameObject healthBar;


    void Start()
    {
        gameOver = FindObjectOfType<Canvas>().transform.GetChild(1).gameObject;
        if (isLocalPlayer)
            healthBar = FindObjectOfType<Canvas>().transform.GetChild(0).GetChild(0).gameObject;
    }

    public void TakeDamage(int amount)
    {
        if (isServer)
        {
            currentHealth -= amount;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                if (isLocalPlayer)
                    gameOver.SetActive(true);
                //Debug.Log("Dead!");
            }
        }


        OnChangeHealth(currentHealth);
    }

    void OnChangeHealth(int health)
    {
        if (isLocalPlayer)
            healthBar.GetComponentInChildren<Text>().text = "Health: " + currentHealth;
        //healthBar.sizeDelta = new Vector2(health, healthBar.sizeDelta.y);
    }
}