using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveWithArrowsCustom : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public float defaultSpeed = 5.0f;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = defaultSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float dispHorizontal = 0;
        float dispVertical = 0;
        if (Input.GetKey(up)) dispVertical = 1;
        if (Input.GetKey(down)) dispVertical = -1;
        if (Input.GetKey(left)) dispHorizontal = -1;
        if (Input.GetKey(right)) dispHorizontal = 1;

        Vector3 displacement = new Vector3(dispHorizontal, 0, dispVertical);
        transform.Translate(displacement * speed * Time.deltaTime);
    }

    public IEnumerator slowMovement()
    {
        speed /= 2;
        Debug.Log("La velocidad es " + speed);
        yield return new WaitForSeconds(5);
        speed = defaultSpeed;
    }

}
