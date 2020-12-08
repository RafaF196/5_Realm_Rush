using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;

    int numTowers = 0;

    public void AddTower(WayPoint waypoint)
    {
        if (numTowers < towerLimit)
        {
            AddNewTower(waypoint);
        }
        else
        {
            MoveExistingTower();
        }
    }

    private void AddNewTower(WayPoint waypoint)
    {
        Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        waypoint.isPlaceable = false;
        numTowers++;
    }

    private void MoveExistingTower()
    {
        throw new NotImplementedException();
    }
}
