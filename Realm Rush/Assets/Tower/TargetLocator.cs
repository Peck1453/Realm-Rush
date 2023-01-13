using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] ParticleSystem projectileParticles;
    [SerializeField] float towerRange = 15;
    Transform target;


    // Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        AimWeapon();
    }

    private void FindClosestTarget()
    {
       Enemy[] enemies = FindObjectsOfType<Enemy>();
       Transform closestTarget = null;
       float maxDistance = Mathf.Infinity;

       foreach (var enemy in enemies)
       {
           float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);

           if (targetDistance < maxDistance)
           {
               closestTarget = enemy.transform;
               maxDistance = targetDistance;
           }
       }

       target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);
        weapon.transform.LookAt(target);
        if(targetDistance < towerRange)
        {
            Attack(true);
        }
        else 
        {
            Attack(false);
        }
    }

    private void Attack(bool isActive)
    {
        var emissionModule = projectileParticles.emission;
        if(isActive)
        {
            emissionModule.enabled = isActive;
        }
    }
}