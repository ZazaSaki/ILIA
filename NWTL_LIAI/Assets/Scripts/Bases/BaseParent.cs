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
    public bool EspecialSeq = false;
    public Transform[] SpawnPointList;

    private string Notification;

    private void Start() {
        if (locked){
            cc().red();
        }else{
            cc().green();
        }

        Notification = "N.B." + id;
        
    }
    
    public void ComputerActivated(){
        Debug.Log("IsActive: " + IsActive + ", locked: " + locked);
        
        if (!IsActive && !locked)
        {
            IsActive = true;
            Debug.Log("Base " + id + " recieved computer action");
            cc().blue();
            NotifyEventManager();
            ComputeKey();
        }else{
            Debug.Log("Base Locked");
        }
        
    }

    public void Reset(){
        IsActive = false;
        cc().green();
        em().Notify(Notification + ".R");
        Debug.Log("Base " + id + " notify:" + Notification + "." + id + ".R");
    }

    public void ComputeKey(){

    }
    
    public void NotifyEventManager(){
        em().Notify(Notification + ".A");
        Debug.Log("Base " + id + " notify: " + Notification + ".A");
    }

    public void UnlockDooor(){
        //door.unlockDoor();
    }

    public void unlock(){
        
        locked = false;
        UnlockDooor();
        //Reset();
    }
    
    private GameMaster gm (){
        return FindObjectOfType<GameMaster>(); 
    }

    private EventManager em(){
        return FindObjectOfType<EventManager>();
    }

    private ColorChanger cc(){
        return GetComponentInChildren<ColorChanger>();
    }
}
