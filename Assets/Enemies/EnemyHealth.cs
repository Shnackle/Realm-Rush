using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int maxHP = 5;

    [Tooltip("Adds amount to maxHP when enemy dies.")]
    [SerializeField] private int difficultyRamp = 1;

    private int currHP;
    public int CurrHP {  get { return currHP; } }

    private Enemy enemy;

    // Start is called before the first frame update
    void OnEnable()
    {
        currHP = maxHP;    
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    private void ProcessHit()
    {
        currHP -= 1;
        if (currHP <= 0)
        {
            maxHP += difficultyRamp;
            enemy.RewardGold();
            gameObject.SetActive(false); //Destroy(gameObject);
        }
    }
}
