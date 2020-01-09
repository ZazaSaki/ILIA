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
        //Move Keys
        if (Input.GetButtonDown("Jump")){moveScript.jump();}

        moveScript.walck(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        
        //Gun Keys
        if (Input.GetButtonDown("Fire1")){gunList.GetActualGun().Fire();}


        //Weapon System Keys
        gunList.ChangeWeapon(Input.GetAxis("Mouse ScrollWheel"));
    }
}