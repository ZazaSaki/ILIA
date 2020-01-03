﻿using UnityEngine;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    public Text AmmoDisplay;
    public WeaponSwitching weaponList;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AmmoDisplay.text = AmmoMessage();
    }

    private string AmmoMessage(){
        return "Ammo: " + getAmmo().ToString() + "/" + getMaxAmmo().ToString();
    }
    private int getAmmo(){
        if (weaponList.GetActualGun() == null)
        {
            return 999;
        }
        return weaponList.GetActualGun().ammo;
    }

    private int getMaxAmmo(){
        if (weaponList.GetActualGun() == null)
        {
            return 999;
        }
        return weaponList.GetActualGun().maxAmmo;
    }
}
