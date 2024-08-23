using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile
{
    public float speed = 20f;
    public int damage = 5;
    public float range = 100f;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        if(Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyShip enemyShip = hitInfo.GetComponent<EnemyShip>();
        EnemyBase enemyBase = hitInfo.GetComponent<EnemyBase>();
        if (enemyShip != null)
        {
            enemyShip.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (enemyBase != null)
        {
            enemyBase.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
