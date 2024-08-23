using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChopperFire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public Vector2 detectionSize = new Vector2(10f, 40f);
    public Vector2 fireDirection;
    public bool nowFire;

    void Start()
    {
        StartCoroutine(fireWhenInRange());
    }

    void Update()
    {
    }

    IEnumerator fireWhenInRange()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.5f);
            
            Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position, detectionSize, 0);

            nowFire = false;
            foreach (Collider2D collider in nearbyColliders)
            {
                Ship ship = collider.GetComponent<Ship>();
                Base base_ = collider.GetComponent<Base>();
                if(ship != null)
                {
                    nowFire = true;
                    fireDirection = transform.position - ship.transform.position;
                }
                if(base_ != null)
                {
                    nowFire = true;
                    fireDirection = transform.position - base_.transform.position;
                }
            }
            if(nowFire)
            {
                Shoot(fireDirection);
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.Euler(0f, 0f, angle));
    }
}
