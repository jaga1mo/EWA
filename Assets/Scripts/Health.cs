using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public object player;
    public int maxHealth = 10;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = gameObject.tag;
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            if(player.ToString() == "Player")
            {
                print("Player died");
            }
            if (player.ToString() == "Enemy")
            {
                print("Enemy killed");
            }

        }

    }
}
