using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoProvisoryInventory : MonoBehaviour
{
    public int ammo;
    public const int maxAmmo = 30;
    
    private void Start() {
        ammo = maxAmmo-6; 
    }
    
    public void ReloadGun(Gun g){
        int missingAmmo = g.maxAmmo - g.ammo;

        if (missingAmmo > this.ammo)
        {
            g.ammo += this.ammo;
            this.ammo = 0;
        }else{
            this.ammo -= missingAmmo;
            g.ammo += missingAmmo;
        }
    }

    public void PickUpAmmo(AmmoItem i){
        if (i.Ammo+this.ammo > maxAmmo){
            i.Ammo = maxAmmo - (i.Ammo + this.ammo);
            this.ammo = maxAmmo;
        }else{
            this.ammo +=i.Ammo;
            i.Ammo = 0;
        }
    }
}
