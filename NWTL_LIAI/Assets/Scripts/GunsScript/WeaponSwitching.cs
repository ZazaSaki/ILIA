using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour{
    private Transform actualGun;
    
    public Transform GunList;
    private int actualGunId = 0;

    public int Ammo;
    public int MaxAmmo;

    
    // Update is called once per frame
    
    private void Start() {
        selectWeapon(actualGunId);
    }
    
    void Update(){

        
        
    }

    public void ChangeWeapon(float MouseWheel){
        int previousWeapon = actualGunId;
        
        //Checking if actualGunId is in GunList range
        if (MouseWheel > 0f){
            if (actualGunId < GunList.childCount - 1)
               actualGunId++;
            else actualGunId = 0;

        }else if (MouseWheel < 0f)
        {
            if (actualGunId > 0)
                actualGunId--;
            else
                actualGunId = GunList.childCount - 1;
        }

        if (actualGunId != previousWeapon){
            selectWeapon(actualGunId);
        }
    }

    public void selectWeapon(int gunID){
        int i = 0;
        string[] MeshList = null;
        //setting new weapon
        foreach (Transform weapon in GunList){
            if (i == gunID){
                //weapon.gameObject.SetActive(true);
                actualGun = weapon;
                MeshList =  weapon.GetComponent<GunParent>().Mesh;
                break;

            }else
                //weapon.gameObject.SetActive(false);
               i++;    
        }

        i=0;
        
        Debug.Log(GetActualGun().id + "searching:");
        printList();
        
        foreach (Transform weapon in GunList){
            
            if (Contains(MeshList, weapon.GetComponent<GunParent>().id)){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        
    }

    private bool Contains(string[] List, string id){
        foreach (string item in List){
            if (item.Equals(id))
            {
                return true;
            }
        }
        return false;
    }

    private void printList(){
        foreach (string item in GetActualGun().Mesh){
            Debug.Log("List :" + item); 
        }
    }

    public GunParent GetActualGun()
    {   
        return actualGun.GetComponent<GunParent>();
    }
}
