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
        IS = gunList = GetComponentInChildren<WeaponSwitching>();
        
    }
    
    // Update is called once per frame
    void Update()
    {   
        //extra priority keys
        if (Input.GetKeyDown("z")){Application.Quit();}
        if (Input.GetButtonDown("Cancel")){Cursor.lockState = CursorLockMode.Confined;}

        //move keys
        //moveScript.SelfMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        

        //Move Keys
        if (Input.GetButtonDown("Jump")){IM.jump();}
        if (Input.GetButtonDown("Left Shift")){IM.sprint();} 
        if (Input.GetButtonUp("Left Shift")){IM.walk();}
        Move();

        //if (IS == null)return;
        
        //Weapon System Keys
        IS.Switch(Input.GetAxis("Mouse ScrollWheel"));
        
        //Gun Keys
        if (Input.GetButtonDown("Fire1")){IF.Fire();}
        if (Input.GetButtonDown("Reload")){IF.Reload();}
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
        Debug.Log("IS signed in");
    }

    public void remove(IKeyHandable IK){
        IK = null;  
    }

    public void Move(){
        
        IM.SelfMove(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    
    }
    
}