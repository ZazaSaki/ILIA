using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : Tool, IMovable
{
    Rigidbody rb;
    public float moveForce;
    public float torqueForce;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelfMove(float HorizontalAxis, float VerticalAxis){
        rb.AddForce(VerticalAxis*transform.forward*moveForce);
        rb.AddTorque(HorizontalAxis*transform.up*torqueForce);
    }
    public void jump(){
    }

    public void sprint(){
        
    }

    public void walk(){
        
    }

    public void id(){Debug.Log("driving....");}
    public void selfAssin(KeyHandler kh){kh.add(this);}

    public override void Action()
    {
        Debug.Log("selfassin");
        selfAssin(comp.GetComponent<KeyHandler>());
    }
}
