using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
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
        findGate(id).unlockDoor();
    }

    public void lockGate(string id){
        findGate(id).lockGate();
    }

    public Gate findGate(string id){
        Gate output = null;

        //searching in every base
        foreach (Gate item in FindObjectsOfType<Gate>())
        {   
            //cheking the wanted id
            if (item.id.Equals(id)){
                output = item;
                Debug.Log("Door ID founded: " + output.id);
                return output;
            }
        }

        //notifing about the non existing id
        if (output == null){
            Debug.Log("item not founded");
        }


        return output;
    }

    public void lockAllGates(){

        //searching in every base
        foreach (Gate item in FindObjectsOfType<Gate>())
        {   
            item.close();
            item.lockDoor();
        }
        
        em().Notify("N.D..LAG");
    }

    private EventManager em(){
        return FindObjectOfType<EventManager>();
    }
}
