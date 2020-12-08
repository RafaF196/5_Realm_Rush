using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 3f;
    [SerializeField] EnemyMovement enemyPrefab;

    [SerializeField] GameObject enemyParent;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RepeteadlySpawnEnemies());
    }

    IEnumerator RepeteadlySpawnEnemies()
    {
        while (true)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            enemy.transform.parent = enemyParent.transform;
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
