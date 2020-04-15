using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip enemyDamagedSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
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
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(enemyDamagedSFX);
    }

    private void KillEnemy()
    {
        var particleInstance = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        particleInstance.transform.parent = FindObjectOfType<EnemySpawner>().gameObject.transform;
        particleInstance.Play();

        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        Destroy(particleInstance.gameObject, particleInstance.main.duration);
        Destroy(gameObject);
    }

}
