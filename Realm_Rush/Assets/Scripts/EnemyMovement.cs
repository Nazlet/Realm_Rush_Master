using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = .5f;
    [SerializeField] float destructionDelay = 1f;
    [SerializeField] ParticleSystem endParticlePrefab;

    // Start is called before the first frame update
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting Patrol..");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(movementPeriod);
        }
        var deathfx = Instantiate(endParticlePrefab, transform.position, Quaternion.identity);
        deathfx.Play();
        Destroy(deathfx.gameObject, deathfx.main.duration);
        Destroy(gameObject, destructionDelay);
    }

    // Update is called once per frame
    void Update()
    {
    }


}
