using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] ParticleSystem goalParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }
    
    IEnumerator FollowPath(List<Waypoint> path)
    {
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        SelfDestruct();
    }

    //Enemy 'self-destructs' when reaching goal.
    private void SelfDestruct()
    {
        var particleInstance = Instantiate(goalParticlePrefab, transform.position, Quaternion.identity);
        particleInstance.transform.parent = FindObjectOfType<EnemySpawner>().gameObject.transform;
        particleInstance.Play();
        Destroy(particleInstance.gameObject, particleInstance.main.duration);
        Destroy(gameObject);
    }
}
