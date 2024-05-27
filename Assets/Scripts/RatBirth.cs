using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatBirth : MonoBehaviour
{
    public float cooldown = 10f;
    public int birthCount = 3;
    float untilSpawn;
    [SerializeField] GameObject smallMouse;
    // Start is called before the first frame update
    void Start()
    {
        untilSpawn = cooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (untilSpawn > 0f)
        {
            untilSpawn -= Time.deltaTime;
        }
        else
        {
            Spawn();
        }
    }

    void Spawn()
    {
        for (int i = 0; i < birthCount; i++)
        {
            Instantiate(smallMouse, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
        untilSpawn = cooldown;
    }
}
