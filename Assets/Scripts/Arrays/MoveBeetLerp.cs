using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target;
    public float distanceFollow = 5.0f;
    public float distanceRespawn = 0.5f;
    public Vector3[] positionsRespawn;
    public float velocity;
    public delegate void ReachingTarget(Vector3 position, int count);
    public static event ReachingTarget reachingTarget;
    private int respawnCount;
    private Vector3 positionRespawn;

    // Start is called before the first frame update
    void Start()

    {
        positionRespawn = transform.position;
        respawnCount = 0;
        reachingTarget?.Invoke(positionRespawn, respawnCount);
    }

    void Update()
    {
        float distanceTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceTarget < distanceRespawn)
        {
            positionRespawn = positionsRespawn[Random.Range(0, positionsRespawn.Length)];
            transform.position = positionRespawn;
            respawnCount++;
            reachingTarget?.Invoke(positionRespawn, respawnCount);
        }
        else if (distanceTarget > distanceRespawn)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
        }
    }
    void FollowTarget()
    {
        float distanceTarget = Vector3.Distance(transform.position, target.transform.position);

        if (distanceTarget < distanceRespawn)
        {
            transform.position = positionsRespawn[Random.Range(0, positionsRespawn.Length)];
        }
        else if (distanceTarget > distanceRespawn)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, velocity * Time.deltaTime);
        }
    }
}
