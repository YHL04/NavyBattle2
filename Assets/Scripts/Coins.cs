using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public Coinbar coinbar;
    public int maxCoins = 1000;
    public int coins = 0;
    public int interval = 1;
    public int coinPerInterval = 100;
    // Start is called before the first frame update
    void Start()
    {
        coinbar.SetMaxCoin(maxCoins);
        StartCoroutine(updateCoins());
    }

    IEnumerator updateCoins()
    {
        while(true)
        {
            yield return new WaitForSeconds(interval);
            coins += coinPerInterval;
            if(coins >= maxCoins)
            {
                coins = maxCoins;
            }
            coinbar.SetCoin(coins);
        }
    }

    public bool SpendCoins(int spend)
    {
        if(spend > coins) 
        {
            return false;
        }

        coins -= spend;
        coinbar.SetCoin(coins);
        return true;
    }
}
