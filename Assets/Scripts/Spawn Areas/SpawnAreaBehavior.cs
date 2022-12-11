using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAreaBehavior : MonoBehaviour
{

    public int minEnemies = 3;
    public int maxEnemies = 6;

    public GameObject pinkVirus;
    // Start is called before the first frame update
    void Start()
    {
        if (this.name == "Spawn Area2")
        {
            minEnemies = 3;
            maxEnemies = 5;

        }

        if (this.name == "Spawn Area1")
        {
            minEnemies = 6;
            maxEnemies = 10;

        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemies()
    {
        BoxCollider2D boxCollider = this.GetComponent<BoxCollider2D>();

       
        int numEnemies = Random.Range(minEnemies, maxEnemies);

        
        for (int i = 0; i < numEnemies; i++)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x), Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y), -5);
                                                
            Instantiate(pinkVirus, spawnPosition, Quaternion.identity);
        }
    }
}
