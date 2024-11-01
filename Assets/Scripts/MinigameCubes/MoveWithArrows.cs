using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveWithArrows : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dispHorizontal = 0;
        float dispVertical = 0;
        if (Input.GetKey(KeyCode.UpArrow)) dispVertical = 1;
        if (Input.GetKey(KeyCode.DownArrow)) dispVertical = -1;
        if (Input.GetKey(KeyCode.LeftArrow)) dispHorizontal = -1;
        if (Input.GetKey(KeyCode.RightArrow)) dispHorizontal = 1;

        Vector3 displacement = new Vector3(dispHorizontal, 0, dispVertical);
        transform.Translate(displacement * speed * Time.deltaTime);
    }
}
