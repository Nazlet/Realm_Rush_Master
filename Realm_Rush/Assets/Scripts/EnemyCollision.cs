using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] int hits = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHits();
        if (hits <= 0)
        {
            KillEnemy();
        }
        
    }

    private void ProcessHits()
    {
        hits = hits -1;
    }

    private void KillEnemy()
    {
        Destroy(gameObject);
    }
}
