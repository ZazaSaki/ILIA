using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTriger : MonoBehaviour {
    
    public Tool item;
    
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other) {
        Debug.Log(item);
        other.transform.GetComponent<PlayerInteractor>().setInteract(item);
    }

    private void OnTriggerExit(Collider other) {
        other.transform.GetComponent<PlayerInteractor>().resetInteract();
    }
    
}
