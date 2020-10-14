using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private IActivatable interact = null;


    private void Update() {
        
        if (Input.GetButtonDown("Interact") && interact != null){
            interact.Action();
        }
    }
    public void setInteract(IActivatable item){
        if (item != null){
          interact = item;  
        }
    }

    public void setInteract(){

    }

    public void resetInteract(){
        interact = null;
    }
}   
