using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    public float lastShootTime;

    public float baseAttackDistance = 10f;
    public float playerAttackDistance = 5f;

    public enum EnemyState { GoToBase, AttackBase, ChasePlayer, AttackPlayer }
    public EnemyState currentState;
    public Sight sight;
    
    public Transform baseTransform;
    private NavMeshAgent navMeshAgent;

    public float rotationSpeed = 5f;
    public float checkInterval = 0.1f;
    private float nextCheckTime = 0f;
    public ParticleSystem muzzleFlash;

    void Start()
    {
        baseTransform = GameObject.Find("Base").transform;
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
        
        navMeshAgent.updateRotation = false;
    }

    void Update()
    {
        if (Time.time >= nextCheckTime)
        {
            nextCheckTime = Time.time + checkInterval;
            EvaluateState();
        }

        PerformAction();
    }
    void EvaluateState()
    {
        if (sight.detectedObject != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, sight.detectedObject.transform.position);
            if (distanceToPlayer > playerAttackDistance * 1.1f)
            {
                currentState = EnemyState.ChasePlayer;
            }
            else if (distanceToPlayer < playerAttackDistance * 0.9f)
            {
                currentState = EnemyState.AttackPlayer;
            }
            else
            {
                if (currentState != EnemyState.ChasePlayer && currentState != EnemyState.AttackPlayer)
                {
                    currentState = EnemyState.ChasePlayer;
                }
            }
        }
        else
        {
            float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

            if (distanceToBase > baseAttackDistance * 1.1f)
            {
                currentState = EnemyState.GoToBase;
            }
            else if (distanceToBase < baseAttackDistance * 0.9f)
            {
                currentState = EnemyState.AttackBase;
            }
            else
            {
                if (currentState != EnemyState.GoToBase && currentState != EnemyState.AttackBase)
                {
                    currentState = EnemyState.GoToBase;
                }
            }
        }
    }

    void PerformAction()
    {
        switch (currentState)
        {
            case EnemyState.GoToBase:
                GoToBase();
                break;
            case EnemyState.AttackBase:
                AttackBase();
                break;
            case EnemyState.ChasePlayer:
                ChasePlayer();
                break;
            case EnemyState.AttackPlayer:
                AttackPlayer();
                break;
        }
    }

    void GoToBase()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(baseTransform.position);
    }

    void AttackBase()
    {
        navMeshAgent.isStopped = true;
        LookTo(baseTransform.position);
        Shoot();
    }

    void ChasePlayer()
    {
        if (sight.detectedObject == null)
            return;

        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(sight.detectedObject.transform.position);

    }

    void AttackPlayer()
    {
        if (sight.detectedObject == null)
            return;

        navMeshAgent.isStopped = true;
        LookTo(sight.detectedObject.transform.position);

        Shoot();
    }

    void Shoot()
    {
        var timeSinceLastShot = Time.time - lastShootTime;
        if (timeSinceLastShot > fireRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            BulletMovement bulletScript = bullet.GetComponent<BulletMovement>();
            if (bulletScript != null)
            {
                bulletScript.speed = 10f;
                // bulletScript.directionTransform = sight.detectedObject?.transform;
            }
            lastShootTime = Time.time;
            muzzleFlash.Play();
        }
    }

    void LookTo(Vector3 target)
    {
        Vector3 direction = target - transform.parent.position;
        direction.y = 0f;
        Vector3 newDir = Vector3.RotateTowards(transform.parent.forward, direction, rotationSpeed * Time.deltaTime, 0f);
        transform.parent.forward = newDir;
    }
}
