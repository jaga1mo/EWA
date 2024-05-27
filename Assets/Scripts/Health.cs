using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryController;

public class Health : MonoBehaviour
{
    public bool isRat = true;
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
			EnemyData data = SaveSystem.LoadEnemy(this);
            int id = GetEnemyID(gameObject.name);
            if(data.enemy[id])
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
        }
		if(player == "Player")
        {
            isRat = false;
            LoadPlayer();
            SavePlayer();
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
        if(player == "Player")
        {
            SavePlayer();
        }
    }
    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer(this);
        
        InventoryController.LoadInventory(data.inventory);

        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
    }

    public void TakeDamage(int amount)
    {
        EnemyData data = SaveSystem.LoadEnemy(this);
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
                int id = GetEnemyID(gameObject.name);
                data.SaveEnemyKill(id);
                SaveSystem.SaveEnemy(this);
            }
        }
        SavePlayer();
    }
    public int GetEnemyID(string name)
    {
        switch (name) 
        {
            case "Pele":return 0;
            case "Pele (1)":return 1;
            case "Pele (2)":return 2;
            case "Pele (3)":return 3;
            case "Pele (4)":return 4;
            case "Pele (5)":return 5;
            case "Pele (6)":return 6;
            case "Pele (7)":return 7;
            case "Pele (8)":return 8;
            case "Pele (9)":return 9;
            case "Pele (10)":return 10;
            case "Pele (11)":return 11;
            case "Pele (12)":return 12;
            case "Pele (13)":return 13;
            case "Pele (14)":return 14;
            case "Pele (15)":return 15;
            case "Pele (16)":return 16;
            case "Pele (17)":return 17;
            case "Pele (18)":return 18;
            case "Pele (19)":return 19;
            case "Pele (20)":return 20;
            case "Pele (21)":return 21;
            case "Pele (22)":return 22;
            case "Pele (23)":return 23;
            case "Pele (24)":return 24;
            case "Pele (25)":return 25;
            case "Pele (26)":return 26;
            case "Pele (27)":return 27;
            case "Pele (28)":return 28;
        }
        return 0;
    }
}
