using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour{

    PlayerMovement moveScript;
    WeaponSwitching gunList;
    
    private void Start() {
        moveScript = GetComponent<PlayerMovement>();
        gunList = GetComponentInChildren<WeaponSwitching>();
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        //move keys
        moveScript.walck(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        //Move Keys
        if (Input.GetButtonDown("Jump")){moveScript.jump();}

        //Run
        if (Input.GetButtonDown("Left Shift")){moveScript.setToRunSpeed();} 
        if (Input.GetButtonUp("Left Shift")){moveScript.setToWalckSpeed();}
        
        //Gun Keys
        if (Input.GetButtonDown("Fire1")){gunList.GetActualGun().Fire();}


        //Weapon System Keys
        gunList.ChangeWeapon(Input.GetAxis("Mouse ScrollWheel"));

        if (Input.GetKeyDown("z")){
            Application.Quit();
        }

        if (Input.GetButtonDown("Cancel")){
            Cursor.lockState = CursorLockMode.Confined;
        }

        if (Input.GetButtonDown("Reload")){
            gunList.GetActualGun().Reload();
        }
    }
}