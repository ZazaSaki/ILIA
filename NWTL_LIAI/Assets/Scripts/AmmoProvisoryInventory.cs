using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoProvisoryInventory : MonoBehaviour
{   

    //test_vars
    public bool InfinitAmmo;
    //*test_vars


    public int Ammo;
    public int MaxAmmo;
    
    private void Start() {
         
    }
    
    public void ReloadGun(WeaponSwitching g){
        int missingAmmo = g.MaxAmmo - g.Ammo;

        //test_Code
        if (InfinitAmmo){
            g.Ammo += missingAmmo;
            return;
        }
        //*test_Code
        
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
