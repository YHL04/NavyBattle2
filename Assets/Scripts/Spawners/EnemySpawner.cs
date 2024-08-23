using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyShipPrefab;
    public GameObject enemyChopperPrefab;
    public float minSpawnTime = 1.0f;
    public float maxSpawnTime = 4.0f;
    public float x = 40;
    public float y = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(enemyWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator enemyWave()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
            if(Random.Range(0, 2) == 0)
            {
                Vector2 randomSpawnPosition = new Vector2(x, y);
                Instantiate(enemyShipPrefab, randomSpawnPosition, Quaternion.identity);
            }
            else
            {
                Vector2 randomSpawnPosition = new Vector2(x, y);
                Instantiate(enemyChopperPrefab, randomSpawnPosition, Quaternion.identity);
            }
        }
    }
}
