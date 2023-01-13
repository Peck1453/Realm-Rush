using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHitpoints = 5;
    [SerializeField] int difficultyRamp = 1;
    int currentHitpoints= 0;

    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }
    void OnEnable()
    {
        currentHitpoints = maxHitpoints;
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currentHitpoints--;
        if (currentHitpoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitpoints+= difficultyRamp;
            enemy.RewardGold();
        }
    }
}
