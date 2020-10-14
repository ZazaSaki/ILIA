using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{   
    private IActivatable Item;
    private void Start() {
        Item = GetComponentInParent<IActivatable>();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerInteractor>() != null){
            other.GetComponent<PlayerInteractor>().setInteract(Item);
            Item.setComponent(other.GetComponent<Transform>());
        }
    }

    private void OnTriggerExit(Collider other) {
       if(other.transform.GetComponent<PlayerInteractor>() != null){
           other.transform.GetComponent<PlayerInteractor>().resetInteract();
           Item.setComponent(null);
        }
    }
}
