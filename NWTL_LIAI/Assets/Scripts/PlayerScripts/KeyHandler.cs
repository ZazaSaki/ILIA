using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour{

    PlayerMovement moveScript;
    WeaponSwitching gunList;
    IMovable IM;
    IFireble IF;
    
    
    private void Start() {
        moveScript = GetComponent<PlayerMovement>();
        gunList = GetComponentInChildren<WeaponSwitching>();
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        
        //move keys
        //moveScript.SelfMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Move();

        //Move Keys
        if (Input.GetButtonDown("Jump")){IM.jump();}

        //Run
        if (Input.GetButtonDown("Left Shift")){IM.sprint();} 
        if (Input.GetButtonUp("Left Shift")){IM.walk();}
        
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
    public void add(IMovable IM){
        Debug.Log(IM);
        this.IM = IM;
        
    }

    public void add(IFireble IM){
        Debug.Log(IM);
        this.IF = IF;
        
    }

    public void remove(IKeyHandable IK){
        
    }

    public void Move(){
        
        IM.SelfMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
    }
    
}