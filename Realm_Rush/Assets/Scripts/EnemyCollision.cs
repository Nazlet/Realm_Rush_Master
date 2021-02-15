using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // TODO check Collider collisionMesh serialized field.  Somehow missed puting that in.

    [SerializeField] int hits = 20;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;



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
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);
        Destroy(gameObject);
        
    }
}
