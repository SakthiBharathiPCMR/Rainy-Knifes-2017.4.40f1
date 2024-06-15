using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public float strength = 80f;
    private string playerName = "player";
    private int mana = 100;
    private bool canAttack = true;
    private float health=100f;
    public Player()
    {
      /*Debug.Log("before " + strength);
        strength = 90f;
        Debug.Log("after " + strength);*/
    }

    public void SetMana(int name)
    {
        mana = name;
    }
    public int GetMana()
    {
        return mana;
    }
    public int Mana
    {
        set
        {
            mana = value;

        }
        get
        {
            return mana;
        }
    }
    public string PlayerName
    {
        set
        {
            playerName = value;
        }
        get
        {
            return playerName;
        }
    }
    public Player(int strength,string playerName)
    {
        this.strength = strength;
        this.playerName = playerName;
        Debug.Log("Strength: " + this.strength);
        Debug.Log("Name: " + this.playerName);
    }
    public void SetPlayer(string newName)
    {
        playerName = newName;
    }
    public string GetPlayer()
    {
        return playerName;
    }
   public virtual void Attack()
    {
        Debug.Log("generic is attacking");
        
    }
    public void Move(float speed)
    {
        Debug.Log("player is moving with the speed of " + speed);
        float distance = CalculateDistance();
    }
    float CalculateDistance()
    {
        return 13.4f;
    }
    float CalculateDamage(float damage)
    {
        health -= damage;
        return health;
    }

}
