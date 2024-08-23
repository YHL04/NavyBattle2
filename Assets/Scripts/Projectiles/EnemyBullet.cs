using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    public float speed = 20f;
    public int damage = 5;
    public float range = 100f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if(Vector2.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Ship ship = hitInfo.GetComponent<Ship>();
        Base base_ = hitInfo.GetComponent<Base>();
        if (ship != null)
        {
            ship.TakeDamage(damage);
            Destroy(gameObject);
        }
        if (base_ != null)
        {
            base_.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
