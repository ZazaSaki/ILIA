using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Door : Tool
{
    public bool Locked = true;
    protected bool Opened = false;

    public string id;
    public Animation anim;

    public override void Action(Transform Player){
        if (!anim.isPlaying){
            if (Opened)close();    
            else open();
        }
    }

    
    public void open(){
        anim.CrossFade("DoorOpen");
        Opened = true;
    }

    public void close(){
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
