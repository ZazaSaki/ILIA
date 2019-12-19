using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseTrigger : MonoBehaviour
{   
    public BaseParent item;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log(item);
        Debug.Log("inside");
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("outside");
 }
}
