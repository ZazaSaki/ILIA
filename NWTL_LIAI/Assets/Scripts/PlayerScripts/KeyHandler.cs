using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour{

    PlayerMovement moveScript;
    WeaponSwitching gunList;
    IMovable IM;
    IFireble IF;
    ISwitchable IS;
    
    
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
        if (Input.GetButtonDown("Fire1")){IF.Fire();}


        //Weapon System Keys
        IS.Switch(Input.GetAxis("Mouse ScrollWheel"));

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

    public void add(IFireble IF){
        Debug.Log(IM);
        this.IF = IF;
        
    }

    public void add(ISwitchable IS){
        Debug.Log(IS);
        this.IS = IS;
    }

    public void remove(IKeyHandable IK){
        
    }

    public void Move(){
        
        IM.SelfMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
    }
    
}