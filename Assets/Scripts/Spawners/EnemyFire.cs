using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    public GameObject firePoint;
    public GameObject bulletPrefab;
    public Vector3 detectionSize = new Vector3(8f, 5f, 0f);
    public Vector3 detectionOffset = new Vector3(4f, 0f, 0f);
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
            
            Collider2D[] nearbyColliders = Physics2D.OverlapBoxAll(transform.position - detectionOffset, detectionSize, 0);

            nowFire = false;
            foreach (Collider2D collider in nearbyColliders)
            {
                Ship ship = collider.GetComponent<Ship>();
                Base base_ = collider.GetComponent<Base>();
                if (ship != null || base_ != null)
                {
                    nowFire = true;
                }
            }
            if(nowFire)
            {
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.transform.position, Quaternion.identity);
    }
}
