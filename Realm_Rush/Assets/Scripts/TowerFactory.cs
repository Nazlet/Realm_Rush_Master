using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] Transform towerParentTransform;

    Queue<Tower> towerQueue = new Queue<Tower>();


    public void AddTower(Waypoint baseWaypoint)
    {
        int numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower(baseWaypoint);
        }

    }
    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        var newTower = Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParentTransform;
        baseWaypoint.isPlaceable = false;
        towerQueue.Enqueue(newTower);
        newTower.baseWaypoint = baseWaypoint;
        baseWaypoint.isPlaceable = false;

    }

    private void MoveExistingTower(Waypoint newbaseWaypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWaypoint.isPlaceable = true; // free-up the block
        newbaseWaypoint.isPlaceable = false;

        oldTower.baseWaypoint = newbaseWaypoint;

        oldTower.transform.position = newbaseWaypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }


}
