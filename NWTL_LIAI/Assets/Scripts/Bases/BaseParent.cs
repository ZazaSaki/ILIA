using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseParent : MonoBehaviour{

    public string id;
    public float health;
    public float r;    
    public bool IsActive = false;
    public bool locked = true;
    public Door door;

    private void Start() {
        if (locked){
            cc().red();
        }else{
            cc().green();
        }
        
    }
    
    public void ComputerActivated(){
        if (!IsActive && !locked)
        {
            IsActive = true;
            Debug.Log("Base " + id + " recieved computer action");
            cc().blue();
            Sequence();
        }else{
            Debug.Log("Base Locked");
        }
        
    }

    public void Reset(){
        IsActive = false;
        cc().green();
    }


    
    public void Sequence(){
        gm().sequence(id);
    }

    public void UnlockDooor(){
        //door.unlockDoor();
    }

    public void unlock(){
        UnlockDooor();
        cc().green();
    }
    
    private GameMaster gm (){
        return FindObjectOfType<GameMaster>(); 
    }

    private ColorChanger cc(){
        return GetComponentInChildren<ColorChanger>();
    }
}
