using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParent : MonoBehaviour, IDamageable{

    public string id;
    public float health;
    public float r;    
    private bool IsActive = false;

    public Door door;

    public GameMaster master;

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0f)
        {
            Die();
        }
    } 

    private void Die()
    {
        Destroy(gameObject);
    }

    public void ComputerActivated(){
        if (!IsActive)
        {
            IsActive = true;
            Debug.Log("Base " + id.ToString() + " recieved computer action");
        }
        
    }

    public void ResetComputer(){
        IsActive = false;
    }
    
    public void Sequence(){

    }

    public void UnlockDooor(){
        door.unlockDoor();
    }
    
}
