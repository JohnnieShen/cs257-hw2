using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    Animator animator;
    public GameObject bulletPrefab;
    public GameObject bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public ParticleSystem muzzleFlash;
    public AudioSource shootSound;
    public int ammo = 10;
    public float fireRate = 1f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        animator.SetBool("Shooting", value.isPressed);
        if (value.isPressed)
        {
            InvokeRepeating("Shoot", fireRate, fireRate);
        } else {
            CancelInvoke();
        }
    }

    private void Shoot() {
        if (ammo > 0 && Time.timeScale>0)
        {
            ammo--;
            // Debug.Log("Ammo: " + ammo);
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.transform.position, transform.rotation);
            BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
            if (bulletScript != null)
            {
                bulletScript.speed = bulletSpeed;
                muzzleFlash.Play();
                shootSound.Play();
                // bulletScript.directionTransform = bulletSpawnPoint.transform;
            }
        }
    }
}
