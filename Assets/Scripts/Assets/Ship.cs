using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : Asset
{
    public int health = 20;
    public float speed = 4.0f;
    public Vector3 detectionSize = new Vector3(4f, 5f, 0f);
    public Vector3 detectionOffset = new Vector3(2f, 0f, 0f);

    void Start()
    {
        SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position + detectionOffset, detectionSize, 0);

        foreach (Collider2D collider in nearbyColliders)
        {
            EnemyShip enemyShip = collider.GetComponent<EnemyShip>();
            EnemyBase enemyBase = collider.GetComponent<EnemyBase>();
            if (enemyShip != null || enemyBase != null)
            {
                return;
            }
        }
        if (transform.position.x < 50)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
