using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{
    [SerializeField] List<Transform> wayPoints;

    float velocity = 2;
    float changeDistance = 0.1f;

    byte nextPosition = 0;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoints[nextPosition].transform.position, velocity * Time.deltaTime);

        if (Vector3.Distance(transform.position, wayPoints[nextPosition].transform.position) <= changeDistance)
        {
            nextPosition++;
            if (nextPosition >= wayPoints.Count)
            {
                nextPosition = 0;
            }
        }

    }
}

