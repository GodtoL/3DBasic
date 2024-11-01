using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Vector3[] coors;
    public float velocity;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(moveBeetweenCoor(coors, velocity));
    }

    IEnumerator moveBeetweenCoor(Vector3[] coors, float velocity)
    {
        if (coors.Length < 2) yield break;
        int indexNextCoor = 0;
        Vector3 start = transform.position;
        while (true)
        {
            Vector3 target = coors[indexNextCoor];
            transform.position = Vector3.MoveTowards(start, target, velocity * Time.deltaTime);
            if (Vector3.Distance(transform.position, target) < 0.1f)
            {
                start = target;
                indexNextCoor = ++indexNextCoor % coors.Length;
            }
            else
            {
                start = transform.position;
                yield return null;
            }
        }
    }
    IEnumerator moveBeetweeenCoor(Vector3[] coors, float velocity, float duration)
    {
        if (coors.Length < 2) yield break;
        int indexNextCoor = 0;
        Vector3 start = transform.position;
        while (true)
        {
            float elapsedTime = 0f;
            Vector3 target = coors[indexNextCoor];
            while (elapsedTime < duration)
            {
                transform.position = Vector3.Lerp(start, target, velocity / duration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            start = target;
            indexNextCoor = ++indexNextCoor % coors.Length;
        }
    }

}
