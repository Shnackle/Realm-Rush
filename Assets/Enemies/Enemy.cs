using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private int goldReward = 25;
    [SerializeField] private int goldPenalty = 25;

    private Bank bank;

    // Start is called before the first frame update
    void Start()
    {
        bank = FindObjectOfType<Bank>();
    }

    public void RewardGold() //EnemyHealth.cs (ie enemy dies)
    {
        if(bank != null)
        {
            bank.Deposit(goldReward);
        }   
    }

    public void StealGold() //EnemyMover.cs (ie enemy makes it to the end)
    {
        if (bank != null)
        {
            bank.Withdraw(goldPenalty);
        }
    }
}
