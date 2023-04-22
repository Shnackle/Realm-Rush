using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{


    [SerializeField] private Transform weapon;
    [SerializeField] private ParticleSystem projectileParticles;
    [SerializeField] private float range = 15f;
    private Transform target;
    



    //Update is called once per frame
    void Update()
    {
        FindClosestTarget();
        if(target != null)
        {
            AimWeapon();
        }
        
    }

    private void FindClosestTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        for (int i = 0; i < enemies.Length; i += 1)
        {
            float targetDistance = Vector3.Distance(transform.position, enemies[i].transform.position);

            if (targetDistance < maxDistance)
            {
                closestTarget = enemies[i].transform;
                maxDistance = targetDistance;
            }
        }

        target = closestTarget;
    }

    private void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);

        if(targetDistance <= range)
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
        emissionModule.enabled = isActive;
    }
}
