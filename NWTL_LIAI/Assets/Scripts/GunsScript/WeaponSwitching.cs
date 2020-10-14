using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitching : MonoBehaviour, ISwitchable{
    private Transform actualGun;
    
    public Transform GunList;
    private int actualGunId = 0;

    public int Ammo;
    public int MaxAmmo;

    bool noGun;

    
    // Update is called once per frame
    
    private void Start() {
        if (GunList.childCount <= 0){
            Debug.Log("0 Child");
            noGun = true;
            return;
        }
        
        selectWeapon(actualGunId);

        Debug.Log("trying self assigng");
        selfAssin(GetComponentInParent<KeyHandler>());
    }
    
    void Update(){

        
        
    }

    //change weapon by mouse wheel
    public void Switch(float MouseWheel){
        int previousWeapon = actualGunId;
        
        //Verify if has guns
        if (GunList.childCount <= 0){
            noGun = true;
            return;
        }

        //set the first picked gun
        if (noGun){
            selectWeapon(actualGunId);
        }

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

        //Select the gun
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
                //Picking the gun and the mesh List
                actualGun = weapon;
                MeshList =  weapon.GetComponent<GunParent>().Mesh;
                GetActualGun().selfAssin(GetComponentInParent<KeyHandler>());
                break;

            }else
               i++;    
        }

        i=0;
        

        string tempId;
        //setting the required meshes
        foreach (Transform weapon in GunList){
            tempId = weapon.GetComponent<GunParent>().id;
            if (Contains(MeshList, tempId) || tempId.Equals(GetActualGun().id)){
                weapon.gameObject.SetActive(true);
            }else{
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
        
    }

    //verify if a list contains a certain word
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
        if (actualGun == null){
            return null;
        }
        return actualGun.GetComponent<GunParent>();
    }

    public void selfAssin(KeyHandler kh)
    {
        id();
        Debug.Log("adding");
        kh.add(this);
    }

    public void id()
    {
        Debug.Log("Weapon Switch");
    }
}
