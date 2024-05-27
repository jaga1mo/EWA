using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private string player;
    public int maxHealth = 10;
    public int currentHealth;
    Renderer renderer;
    List<Color> oldColors = new List<Color>();
    Material[] newMaterials;
    public float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
        currentHealth = maxHealth;
        player = gameObject.tag;
        if (player == "Enemy")
        {
            renderer = GetComponent<Renderer>();
            newMaterials = renderer.materials;
            for (var i = 0; i < renderer.materials.Length; i++)
            {
                oldColors.Add(renderer.materials[i].color);
            }
            for (var i = 0; i < renderer.materials.Length; i++)
            {
                newMaterials[i].color = Color.red;
            }
        }
        
    }
    void Update()
    {
        if (player == "Enemy")
        {
            if (cooldown > 0f)
            {
                cooldown -= Time.deltaTime;
            }
            else
            {
                for (var i = 0; i < renderer.materials.Length; i++)
                {
                    renderer.materials[i].color = oldColors[i];
                }
            }
        }
    }
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (player == "Enemy")
        {
            renderer.materials = newMaterials;
            cooldown = 20f;
        }
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
