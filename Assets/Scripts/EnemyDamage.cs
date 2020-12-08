using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit!");
        ProcessHit();
        if (hitPoints < 1)
        {
            killEnemy();
        }
    }

    private void ProcessHit()
    {
        hitPoints--;
    }

    private void killEnemy()
    {
        Destroy(gameObject);
    }
}
