using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public ParticleSystem muzzleFlash;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
        //     GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
        //     BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
        //     if (bulletScript != null)
        //     {
        //         bulletScript.speed = bulletSpeed;
        //         bulletScript.directionTransform = bulletSpawnPoint.transform;
        //     }
        // }
        
    }
    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
            if (bulletScript != null)
            {
                bulletScript.speed = bulletSpeed;
                muzzleFlash.Play();
                // bulletScript.directionTransform = bulletSpawnPoint.transform;
            }
        }
        
    }
}
