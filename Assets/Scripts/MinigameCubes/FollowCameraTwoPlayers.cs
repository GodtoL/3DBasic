using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraTwoPlayers : MonoBehaviour
{
    public Transform cube1;
    public Transform cube2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 midPoint = (cube1.position + cube2.position) /2;
        float distance = (cube1.position - cube2.position).magnitude;
        distance = Mathf.Max(distance, 10.0f);
        transform.position = midPoint - transform.forward * distance;
        
    }
}
