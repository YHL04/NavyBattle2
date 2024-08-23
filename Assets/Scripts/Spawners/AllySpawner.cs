using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    public GameObject shipPrefab;
    public GameObject chopperPrefab;
    public Coins coins;
    public float secondSpawn = 1.0f;
    public float x = 36;
    public float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(coins.SpendCoins(100))
            {
                Vector2 spawnPosition = new Vector2(x, y);
                Instantiate(shipPrefab, spawnPosition, Quaternion.identity);
            }
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            if(coins.SpendCoins(200))
            {
                Vector2 spawnPosition = new Vector2(x, y + 2);
                Instantiate(chopperPrefab, spawnPosition, Quaternion.identity);
            }
        }
    }
}
