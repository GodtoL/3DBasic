using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CoinType{
    gold,
    silver,
    bronze
}
public class Coin : MonoBehaviour
{
    public float velocityRotation = 1;
    private CoinType coinType; 
    public Transform cube1;
    public Transform cube2;
    public float distance;
    private static int coins = 1;
    public delegate void ScoreDelegate(CoinType coinType, int player);
    public static event ScoreDelegate OnCoinCollected;
    // Start is called before the first frame update
    void Start()
    {
        Array values = Enum.GetValues(typeof(CoinType));
        coinType = (CoinType)values.GetValue(new System.Random().Next(values.Length));
        CoinColor();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget1 = Vector3.Distance(transform.position, cube1.position);
        float distanceToTarget2 = Vector3.Distance(transform.position, cube2.position);
        if (distanceToTarget1 < distance || distanceToTarget2 < distance)
        {
            if (distanceToTarget1 < distanceToTarget2)
            {
                MoveWithArrowsCustom moveScript = cube1.GetComponent<MoveWithArrowsCustom>();
                if (moveScript != null && coinType == CoinType.gold)
                {
                    moveScript.StartCoroutine(moveScript.slowMovement());
                }

                OnCoinCollected?.Invoke(coinType, 1);
                MoveCoin();
            }
            else
            {
                MoveWithArrowsCustom moveScript = cube2.GetComponent<MoveWithArrowsCustom>();
                if (moveScript != null && coinType == CoinType.gold)
                {
                    moveScript.StartCoroutine(moveScript.slowMovement());
                }
                OnCoinCollected?.Invoke(coinType, 2);
                MoveCoin();
            }
        }
        transform.Rotate(0,0,velocityRotation* Time.deltaTime);
    
    }
    void CoinColor()
    {
        Renderer renderer = GetComponent<Renderer>();
        switch (coinType)
        {
            case CoinType.gold:
                renderer.material.color = Color.yellow; 
                break;
            case CoinType.silver:
                renderer.material.color = Color.gray; 
                break;
            case CoinType.bronze:
                renderer.material.color = new Color(0.8f, 0.5f, 0.2f);
                break;
        }

    }
    void MoveCoin()
    {
        Vector3 newPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 0, UnityEngine.Random.Range(-10, 11));
        transform.position = newPosition;
        if (UnityEngine.Random.Range(0,2) == 0 && coins < 5)
        {

                    Vector3 newRandomPosition = new Vector3(UnityEngine.Random.Range(-10, 11), 0, UnityEngine.Random.Range(-10, 11));
                    Quaternion quaternionInitial = Quaternion.Euler(90, 0, 0);
                    Instantiate(gameObject, newRandomPosition, quaternionInitial);
                    coins++;
                    Debug.Log("monedas: " + coins);

            
        }
    }
}
