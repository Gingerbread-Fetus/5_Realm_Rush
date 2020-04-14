using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

     void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if(hitPoints <= 1)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints -= 1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
