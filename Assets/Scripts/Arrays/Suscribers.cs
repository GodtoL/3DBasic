using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Suscribers : MonoBehaviour
{
    [SerializeField] private Text countText;
    public void OnEnable()
    {
        Follow.reachingTarget += UpdateCount;
        Follow.reachingTarget += PositionPrinter;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void UpdateCount(Vector3 position, int count)
    {
        countText.text = "Cantidad de respawns: " + count;
    }

    void PositionPrinter(Vector3 position, int count)
    {
        Debug.Log("La posicion de respawn es: " + position);
    }
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
