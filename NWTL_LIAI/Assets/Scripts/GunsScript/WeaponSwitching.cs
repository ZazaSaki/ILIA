using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour{
    private Transform actualGun;
    
    public Transform GunList;
    private int actualGunId = 0;
    // Update is called once per frame
    
    private void Start() {
        selectWeapon();
    }
    
    void Update(){

        
        int previousWeapon = actualGunId;
        
        //Checking if actualGunId is in GunList range
        if (Input.GetAxis("Mouse ScrollWheel") > 0f){
            if (actualGunId < GunList.childCount - 1)
               actualGunId++;
            else actualGunId = 0;

        }else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (actualGunId > 0)
                actualGunId--;
            else
                actualGunId = GunList.childCount - 1;
        }

        if (actualGunId != previousWeapon){
            selectWeapon();
        }
    }

    private void selectWeapon(){
        int i = 0;
        
        //setting new weapon
        foreach (Transform weapon in GunList){
            if (i == actualGunId){
                weapon.gameObject.SetActive(true);
                actualGun = weapon;
            }else
                weapon.gameObject.SetActive(false);

            i++;
            
        }
    }

    public Gun GetActualGun()
    {   
        return actualGun.GetComponent<Gun>();
    }
}
