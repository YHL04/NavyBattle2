using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chopper : Asset
{
    public int health = 20;
    public float maxSpeed = 3.0f;
    public GameObject image;
    public SpriteRenderer renderer;
    public Vector2 velocity = new Vector2(0f, 0f);
    public Vector2 detectionSize = new Vector2(8f, 70f);

    void Start()
    {
        SetMaxHealth(health);
        renderer = image.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if(velocity.x >= 0)
        {
            renderer.flipX = false;
        }
        else
        {
            renderer.flipX = true;
        }

        Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0);

        foreach (Collider2D collider in nearbyColliders)
        {
            EnemyShip enemyShip = collider.GetComponent<EnemyShip>();
            EnemyBase enemyBase = collider.GetComponent<EnemyBase>();
            if (enemyShip != null)
            {
                velocity += Vector2.ClampMagnitude(enemyShip.transform.position - transform.position, 0.3f);
                KeepPosition();
                Move();
                return;
            }
            if (enemyBase != null)
            {
                velocity += Vector2.ClampMagnitude(enemyBase.transform.position - transform.position, 0.3f);
                KeepPosition();
                Move();
                return;
            }
        }

        ForwardDrift();
        KeepPosition();
        Move();
    }

    public void ForwardDrift()
    {
        velocity += new Vector2(0.05f, 0.0f);
        velocity += new Vector2(0, Random.Range(-0.1f, 0.1f));
    }

    public void KeepPosition()
    {
        if(transform.position.y > 10)
        {
            velocity += new Vector2(0, Random.Range(-0.2f, 0.0f));
        }
        if(transform.position.y < 2)
        {
            velocity += new Vector2(0, Random.Range(0.0f, 0.3f));
        }
    }

    public void Move()
    {
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        transform.Translate(velocity * Time.deltaTime);
    }

}
