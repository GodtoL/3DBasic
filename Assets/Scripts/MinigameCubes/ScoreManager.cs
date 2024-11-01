using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private Text score1;
    [SerializeField] private Text score2;
    [SerializeField] private GameObject cube1;
    [SerializeField] private GameObject cube2;
    private int scorePlayer1 = 0;
    private int scorePlayer2 = 0;
    public int maxScore = 25;
    public void OnEnable()
    {
        Coin.OnCoinCollected += UpdateUIPlayer;
    }
    // Start is called before the first frame update
    void Start()
    {
        score1.text = $"{cube1.name}:  {scorePlayer1}";
        score2.text = $"{cube2.name}:  {scorePlayer2}";
    }

    // Update is called once per frame
    void Update()
    {
        if (scorePlayer1 >= maxScore || scorePlayer2 >= maxScore)
        {
            Time.timeScale = 0f;
        }
    }
    void UpdateUIPlayer(CoinType coinType, int player)
    {
        if (player == 1)
        {
            scorePlayer1 += TypeOfCoin(coinType) ;
            score1.text = $"{cube1.name}:  {scorePlayer1}";
        }
        else
        {
            scorePlayer2 += TypeOfCoin(coinType);
            score2.text = $"{cube2.name}:  {scorePlayer2}";
        }
    }

    int TypeOfCoin(CoinType coinType)
    {
        switch (coinType)
        {
            case CoinType.gold: return 5;
            case CoinType.silver: return 3;
            case CoinType.bronze: return 1;
            default: return 0;
        }
    }
}
