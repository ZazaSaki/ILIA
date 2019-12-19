using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : Tool
{
    public bool Locked = true;
    private bool Opened = false;

    public Animation anim;

    public override void Action(){
        if (!anim.isPlaying)
        {
            if (Opened)close();    
            else open();
    }
        }

    public void open(){
        Debug.Log("open");
        anim.CrossFade("DoorOpen");
        Opened = true;
    }

    public void close(){
        Debug.Log("close");
        anim.CrossFade("CloseDoor");
        Opened = false;
    }

    public void lockDoor(){
        Locked = true;
    }

    public void unlockDoor(){
        Locked = false;
    }

    public bool IsLocked(){
        return Locked;
    }
}
