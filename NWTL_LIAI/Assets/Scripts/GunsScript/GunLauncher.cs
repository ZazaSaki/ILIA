using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLauncher : GunParent
{
    override public void Shoot(){
        Debug.Log("ssssssshhhhhhhhhhhhhhhhhhhhhhhhhhhhhhh..................... BUUUUUUUUMMMMMMMMMMM");
        decreaseAmmo();
    }


}
