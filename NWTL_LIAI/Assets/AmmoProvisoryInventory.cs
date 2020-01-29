using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoProvisoryInventory : MonoBehaviour
{
    public int Ammo;
    public const int MaxAmmo = 30;
    
    private void Start() {
        Ammo = MaxAmmo-6; 
    }
    
    public void ReloadGun(WeaponSwitching g){
        int missingAmmo = g.MaxAmmo - g.Ammo;

        if (missingAmmo > this.Ammo)
        {
            g.Ammo += this.Ammo;
            this.Ammo = 0;
        }else{
            this.Ammo -= missingAmmo;
            g.Ammo += missingAmmo;
        }
    }

    public void PickUpAmmo(AmmoItem i){
        if (i.Ammo+this.Ammo > MaxAmmo){
            i.Ammo = MaxAmmo - (i.Ammo + this.Ammo);
            this.Ammo = MaxAmmo;
        }else{
            this.Ammo +=i.Ammo;
            i.Ammo = 0;
        }
    }
}
