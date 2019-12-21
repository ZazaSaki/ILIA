using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParent : MonoBehaviour{

    public string id;
    public float health;
    public float r;    
    private bool IsActive = false;

    public Door door;

    
    public void ComputerActivated(){
        if (!IsActive)
        {
            IsActive = true;
            Debug.Log("Base " + id.ToString() + " recieved computer action");
            Sequence();
        }
        
    }

    public void ResetComputer(){
        IsActive = false;
    }


    
    public void Sequence(){
        gm().sequence(id);
    }

    public void UnlockDooor(){
        door.unlockDoor();
    }
    
    private GameMaster gm (){
        return FindObjectOfType<GameMaster>(); 
    }
}
