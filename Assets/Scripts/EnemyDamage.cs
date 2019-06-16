using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int hitPoints = 5;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip enemyDeathSFX;

    AudioSource myAudioSource;
    

    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }


    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;        
        hitParticlePrefab.Play();
        myAudioSource.PlayOneShot(hitSFX);
    }

    private void KillEnemy()
    {
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();        

        Destroy(vfx.gameObject, vfx.main.duration); // need to specify gameObject
        AudioSource.PlayClipAtPoint(enemyDeathSFX, Camera.main.transform.position);

        Destroy(gameObject);     
    }
}
