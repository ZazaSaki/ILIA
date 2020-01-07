using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHandler : MonoBehaviour{

    PlayerMovement moveScript;
    
    private void Start() {
        moveScript = GetComponent<PlayerMovement>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            moveScript.jump();
        }

        moveScript.walck(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
