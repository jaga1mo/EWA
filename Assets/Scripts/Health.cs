using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private string player;
    public int maxHealth = 10;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
        player = gameObject.tag;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if(player == "Player")
            {
                print("Player died");
            }
            if (player == "Enemy")
            {
                gameObject.SetActive(false);
                print("Enemy killed");
            }

        }

    }
}
