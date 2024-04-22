using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerDamage : MonoBehaviour
{

    [SerializeField] private Health playerHealth;
    [SerializeField] private TMP_Text wandLabel;
    public int damage = 1;
    public int heal = 2;
    List<Collider> InRange = new List<Collider> ();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !PlayerMovement.dialogue)
        {
            int wandUses = int.Parse(wandLabel.text);
            if (wandUses > 0)
            {
                DealDamage(damage);
                wandUses--;
                wandLabel.text = wandUses.ToString();
            }
        }
        if (Input.GetMouseButtonDown(1) && !PlayerMovement.dialogue)
        {
            int wandUses = int.Parse(wandLabel.text);
            if (wandUses > 0)
            {
                HealSelf(heal);
                wandUses--;
                wandLabel.text = wandUses.ToString();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print(other.gameObject.name + " entered attack range");
            InRange.Add(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            print(other.gameObject.name + " left attack range");
            InRange.Remove(other);
        }
    }

    void DealDamage (int damage)
    {
        foreach(var coll in InRange)
        {
            Health enemyHealthScript = coll.GetComponent<Health>();
            if (enemyHealthScript != null)
            {
                enemyHealthScript.TakeDamage(damage);
            }
        }
    }

    void HealSelf (int heal)
    {
        playerHealth.TakeDamage(-1 * heal);
    }
}
