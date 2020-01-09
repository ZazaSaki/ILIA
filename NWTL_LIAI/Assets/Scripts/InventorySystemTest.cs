using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySystemTest : Tool
{    
    public Inventory inventory;
    public GameObject presskey;
    private bool nearInv;
    private bool keyPressed;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && nearInv == true)
        {
            keyPressed = !keyPressed;
            inventory.Enable(keyPressed);
        }
    }

   
    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            presskey.SetActive(true);
            Debug.Log("1");
            nearInv = true;
        }
    }
 
    void OnTriggerExit (Collider other) 
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("3");
            presskey.SetActive(false);
            inventory.Enable(false);
            nearInv = false;    
        }
    }

    
    public override void Action(){
    }
}
