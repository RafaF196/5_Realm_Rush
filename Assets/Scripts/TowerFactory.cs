using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
    [SerializeField] int towerLimit = 5;
    [SerializeField] Tower towerPrefab;
    [SerializeField] GameObject towerParent;

    Queue<Tower> towerQueue = new Queue<Tower>();

    int numTowers;

    public void AddTower(WayPoint waypoint)
    {
        numTowers = towerQueue.Count;
        if (numTowers < towerLimit)
        {
            AddNewTower(waypoint);
        }
        else
        {
            MoveExistingTower(waypoint);
        }
    }

    private void AddNewTower(WayPoint waypoint)
    {
        var newTower = Instantiate(towerPrefab, waypoint.transform.position, Quaternion.identity);
        newTower.transform.parent = towerParent.transform;
        waypoint.isPlaceable = false;

        newTower.baseWayPoint = waypoint;
        waypoint.isPlaceable = false;

        towerQueue.Enqueue(newTower);
    }

    private void MoveExistingTower(WayPoint waypoint)
    {
        var oldTower = towerQueue.Dequeue();

        oldTower.baseWayPoint.isPlaceable = true;
        waypoint.isPlaceable = false;

        oldTower.baseWayPoint = waypoint;

        oldTower.transform.position = waypoint.transform.position;

        towerQueue.Enqueue(oldTower);
    }
}
