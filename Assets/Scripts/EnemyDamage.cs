using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public Health playerHealth;
    public int damage = 1;
    public bool PlayerInRange = false;
    public float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange && cooldown <= 0f)
        {
            playerHealth.TakeDamage(damage);
            cooldown = 1f;
        }
        else
        {
            cooldown -= Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            playerHealth.TakeDamage(damage);
            PlayerInRange = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
}
