using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void unlockDoor(string id){
        findDoor(id).unlockDoor();
    }

    public void lockDoor(string id){
        findDoor(id).lockDoor();
    }

    public Door findDoor(string id){
        Door output = null;

        //searching in every base
        foreach (Door item in FindObjectsOfType<Door>())
        {   
            //cheking the wanted id
            if (item.id.Equals(id)){
                output = item;
                Debug.Log("Base ID founded: " + output.id);
                return output;
            }
        }

        //notifing about the non existing id
        if (output == null){
            Debug.Log("item not founded");
        }


        return output;
    }
}
