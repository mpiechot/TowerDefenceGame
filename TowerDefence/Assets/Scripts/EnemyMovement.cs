using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private float targetDistance = .4f;

    private Transform target;
    private int wayPointIndex = 0;


    void Start()
    {
        target = Waypoints.waypoints[0];
        enemy = GetComponent<Enemy>();
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(target.position, transform.position) <= targetDistance)
        {
            GetNextWaypoint();
        }
        enemy.speed = enemy.normalSpeed;
    }
    void GetNextWaypoint()
    {
        if(wayPointIndex >= Waypoints.waypoints.Length - 1)
        {
            PlayerStats.lives--;
            Destroy(gameObject);
            return;
        }
        target = Waypoints.waypoints[++wayPointIndex];
    }

}
