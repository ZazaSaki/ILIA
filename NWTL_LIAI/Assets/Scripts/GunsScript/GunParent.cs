using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GunParent : MonoBehaviour
{   //Mesh
    public string[] Mesh; 
    public string id;

    public bool IsFiring = false;
    public float nextTimeToFire = 0f;
    public float fireRate = 50f;
    public int AmmoByShot;
    protected WeaponSwitching WeaponHolder;

    protected Camera fpsCam;
    
    // Start is called before the first frame update
    void Start(){
        WeaponHolder = GetComponentInParent<WeaponSwitching>();
        fpsCam = GetComponentInParent<Camera>();
        
        string[] temp = Mesh;
        Mesh = new string[temp.Length + 1];
        for (int i = 0; i < temp.Length; i++){
            Debug.Log(temp[i]);
            Mesh[i+1] = temp[i];
        }
        Mesh[0] = id;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFiring){
            if (Time.time >= nextTimeToFire){
                IsFiring = false;
            }
        }
    }

    public void Fire(){
        if (Time.time >= nextTimeToFire && IsEnoughAmmo()){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            IsFiring = true;
        }
    }

    public abstract void Shoot();
    
    public void Reload(){
        GetComponentInParent<AmmoProvisoryInventory>().ReloadGun(WeaponHolder);
    }

    protected void decreaseAmmo(){
         WeaponHolder.Ammo -= AmmoByShot;
    }

    protected bool IsEnoughAmmo(){
        return !(WeaponHolder.Ammo < AmmoByShot);
    }
}
