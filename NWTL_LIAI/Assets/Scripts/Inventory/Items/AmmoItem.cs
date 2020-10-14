using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : Tool
{   
    public int Ammo = 5;
    public override void Action(){
        comp.GetComponent<AmmoProvisoryInventory>().PickUpAmmo(this);
        if (Ammo == 0)
        {
            Destroy(gameObject);
        }
    }


    
}
