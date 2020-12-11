using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] GameObject enemyParent;

    [SerializeField] AudioClip spawnedEnemySFX;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeteadlySpawnEnemies());
    }

    IEnumerator RepeteadlySpawnEnemies()
    {
        while (true)
        {
            GetComponent<AudioSource>().PlayOneShot(spawnedEnemySFX);
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
