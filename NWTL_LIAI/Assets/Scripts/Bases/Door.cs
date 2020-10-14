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

    public override void Action(){
        if (!anim.isPlaying){
            if (Opened)close();    
            else open();
        }
    }

    
    public virtual void open(){
        anim.CrossFade("DoorOpen");
        Opened = true;
    }

    public virtual void close(){
        anim.CrossFade("CloseDoor");
        Opened = false;
    }

    public virtual void lockDoor(){
        Locked = true;
        em().Notify("N.D." + id + ".L");
    }

    public virtual void unlockDoor(){
        Locked = false;
        em().Notify("N.D." + id + ".U");
    }

    public bool IsLocked(){
        return Locked;
    }

    public EventManager em(){
        return FindObjectOfType<EventManager>();
    }
}
