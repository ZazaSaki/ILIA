using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    private Tool interact = null;


    private void Update() {
        
        if (Input.GetButtonDown("Interact") && interact != null){
            interact.Action(GetComponent<Transform>());
        }
    }
    public void setInteract(Tool item){
        if (item != null){
          interact = item;  
        }
    }

    public void resetInteract(){
        interact = null;
    }
}   
