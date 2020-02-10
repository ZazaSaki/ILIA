using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLauncher : GunParent{

    public GameObject Projectile;
    public Transform lauchingPoint;
    public float lauchingForce;
    override public void Shoot(){
        Debug.Log("ssssssshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh..................... BUUUUUUUUMMMMMMMMMMM");
        
        GameObject temp = Instantiate(Projectile, lauchingPoint.position, new Quaternion());
        Rigidbody rb = temp.GetComponent<Rigidbody>();

        rb.AddForce(GetComponentInParent<Camera>().GetComponent<Transform>().forward*lauchingForce, ForceMode.VelocityChange);
        
        decreaseAmmo();
    }


}
