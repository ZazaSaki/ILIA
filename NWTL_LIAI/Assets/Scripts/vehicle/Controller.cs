using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject prop;
    public GameMaster cm;
    public float baseForce;

    // Start is called before the first frame update
    void Start()
    {
        rb.centerOfMass = cm.transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        goForward(Input.GetAxis("Vertical"));

    }

    public void goForward(float axis){
        rb.AddForceAtPosition(Time.deltaTime * transform.TransformDirection(Vector3.forward) * axis * baseForce, prop.transform.position);
    }

    public void turn(float axis){
            //rb.AddTorque(Time.deltaTime );
    }
}
