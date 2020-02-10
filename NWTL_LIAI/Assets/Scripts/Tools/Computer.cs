using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Tool{

    public BaseParent baseParent; 
    
    
    public override void Action(Transform Player)
    {
        Debug.Log("Computer is Active");
        baseParent.ComputerActivated();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
