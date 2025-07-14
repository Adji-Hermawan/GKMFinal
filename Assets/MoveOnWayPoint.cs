using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnWayPoint : MonoBehaviour
{
    public List<GameObject> waypoints; //ini buat list object untuk posisinya
    public float speed = 2;
    int index = 0;
    void Start()
    {

    }

    public void Update()
    {
        Vector3 destination = waypoints[index].transform.position;
        Vector3 newPos = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
        transform.position = newPos;

        float distance = Vector3.Distance(transform.position, destination);
        if (distance <= 0.05)
        {
            if (index < waypoints.Count - 1)
                index++;
        }
    }
}
