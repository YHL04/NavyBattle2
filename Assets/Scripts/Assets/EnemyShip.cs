using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : Asset
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
        Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position - detectionOffset, detectionSize, 0);

        foreach (Collider2D collider in nearbyColliders)
        {
            Ship ship = collider.GetComponent<Ship>();
            Base base_ = collider.GetComponent<Base>();
            if (ship != null || base_ != null)
            {
                return;
            }
        }
        if (transform.position.x > 0) {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
