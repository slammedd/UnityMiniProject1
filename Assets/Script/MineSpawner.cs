using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawner : MonoBehaviour
{
    public GameObject mine;

    private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        InvokeRepeating("SpawnMine", 0, 3);
    }

    void SpawnMine()
    {
        Vector2 randomSpawnPos = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));

        if(player != null)
        {
            Instantiate(mine, randomSpawnPos, Quaternion.identity);
        }
    }
}
