﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numTowers = 0;


    public void AddTower(Waypoint baseWaypoint)
    {
        if (numTowers < towerLimit)
        {
            InstantiateNewTower(baseWaypoint);
        }
        else
        {
            MoveExistingTower();
        }

    }

    private static void MoveExistingTower()
    {
        Debug.Log("Max towers reached");
        // todo actually move!
    }

    private void InstantiateNewTower(Waypoint baseWaypoint)
    {
        Instantiate(towerPrefab, baseWaypoint.transform.position, Quaternion.identity);
        baseWaypoint.isPlaceable = false;
        numTowers++;
    }
}
