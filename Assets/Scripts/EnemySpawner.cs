using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)] 
    [SerializeField] float secondsBetweenSpawns = 4f;
    [SerializeField] EnemyMovement enemyPrefab; //Restricts to prefabs with EnemyMovement script
    [SerializeField] Transform enemyParentTransform;

    int score = 0;

    [SerializeField] int scoreIncrease = 1;
    [SerializeField] Text scoreText;

    [SerializeField] AudioClip spawnedEnemySFX;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeatedlySpawnEnemies());
        scoreText.text = score.ToString();
    }

    IEnumerator RepeatedlySpawnEnemies()
    {
        while (true) // runs forever
        {
            AddScore();

            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);

            var newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

            newEnemy.transform.parent = enemyParentTransform;
            
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }

    }

    private void AddScore()
    {
        score += scoreIncrease;
        scoreText.text = score.ToString();
    }
}
