using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int maxHp = 1000;
    public int currentHP = 1000;

    [SerializeField] StatusBar hpBar;

    //view method created in StatusBar.cs
    public void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP <= 0)
        {
            Debug.Log("Character is dead");
        }
        hpBar.SetState(currentHP, maxHp);
    }


    //ensures player's hp never is greater than max hp
    public void Heal(int amount)
    {
        if (currentHP <= 0) { return; }

        currentHP += amount;
        if (currentHP > maxHp)
        { 
            currentHP = maxHp; 
        }
    }
}
