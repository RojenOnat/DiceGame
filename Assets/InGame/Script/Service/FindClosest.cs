using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindClosest 
{
    public int GetNearestObjectIndex(Vector3 playerPosition, List<GameObject> objectList)
    {
        int nearestIndex = -1;
        float shortestDistance = Mathf.Infinity;

        for (int i = 0; i < objectList.Count; i++)
        {
            float distance = Vector3.Distance(playerPosition, objectList[i].transform.position);
            if (distance < shortestDistance)
            {
                shortestDistance = distance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }
}
