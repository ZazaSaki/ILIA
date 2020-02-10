using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoItem : Tool
{   
    public int Ammo = 5;
    public override void Action(Transform Player){
        Player.GetComponent<AmmoProvisoryInventory>().PickUpAmmo(this);
        if (Ammo == 0)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
