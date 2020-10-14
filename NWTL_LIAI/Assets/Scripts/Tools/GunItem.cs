using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : Tool
{   
    public GameObject drop;
    
    public override void Action(){
        
        GameObject Wh = comp.GetComponentInChildren<WeaponSwitching>().gameObject;

        Instantiate(drop, Wh.transform);
        Destroy(gameObject);
    }

}
