using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private bool inventoryEnabled;
    public GameObject inventory;

    private int allSlots;
    private int enabledSlots;
    private GameObject[] slot;

    private List<string> HashKeys = new List<string>();

    public GameObject slotHolder;


    void start()
    {
        Enable(false);
        allSlots = 40;
        slot = new GameObject[allSlots];

        for (int i = 0; i < allSlots; i++)
        {
            slot[i] = slotHolder.transform.GetChild(i).gameObject;
        }       
    }

    void Update()
    {

    }

    public void Enable(bool on){
        inventory.SetActive(on);
    }

    
    
    public bool pickupItem(GameObject g){
        for (int i = 0; i < slot.Length; i++){
            if (slot[i] == null){
                slot[i] = g;
                return true;
            }
        }

        return false;
    }

    private void removeItem(int id){
        slot[id] = null;
    }

    private void addKey(string hashCode){
        if (!hasAccess(hashCode)){
            HashKeys.Add(hashCode);
        }
        
    }
    
    //search for keys function 
    public bool hasAccess(string hashKey){
        
        foreach (string item in HashKeys){
            //search for keys
            if (item.Equals(hashKey))
            {
                return true;
            }
        }

        return false;
    }

    public bool hasKey(){
        foreach (GameObject item in slot){
            if (item.GetComponent<Key>() != null){
                return true;
            }
        }

        return false;
    }
}
