using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemTest : Tool
{    
    public Inventory inventory;

   
    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("TRIGGERED");
            inventory.Enable(true);         
        }
    }
 
    void OnTriggerExit (Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Exited");
            inventory.Enable(false);  
        }
    }

    public override void Action(){
        
    }
 
}
