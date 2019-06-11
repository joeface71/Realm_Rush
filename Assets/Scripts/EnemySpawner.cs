using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab; //Restricts to prefabs with EnemyMovement script
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // runs forever
        {
            print("Spawning Enemy");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
       
    }
}
