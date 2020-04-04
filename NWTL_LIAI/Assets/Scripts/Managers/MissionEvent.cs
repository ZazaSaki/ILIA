using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionEvent : MonoBehaviour
{
    private string Notification;
    
    // Start is called before the first frame update
    void Start()
    {   
        Vector3 l = transform.position;
        Notification = "N.M." + (float)l.x + "," + (float)l.y + "," + (float)l.z + ".A";
        Debug.Log(Notification);
    }


    private void OnTriggerEnter(Collider other) {
        Debug.Log("colide");
        
        if (other.tag == "Player"){
            FindObjectOfType<EventManager>().Notify(Notification);
            Debug.Log("auto bum next");
            Destroy(gameObject);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
