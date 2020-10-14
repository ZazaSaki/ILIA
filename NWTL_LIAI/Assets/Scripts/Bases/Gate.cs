using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : Door
{   
    public GameObject BodyLock;
    public ColorChanger Changer;
    // Start is called before the first frame update
    void Start()
    {
        Locked = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Action(){
        if (Opened)close(); else open();
    }

    public override void open(){
        if(Locked)return;
        BodyLock.active = false;
        Opened = true;
    }

    public override void close(){
        BodyLock.active = true;
        Opened = false;
    }

    public override void lockDoor(){
        base.lockDoor();
        Changer.red();
    }

    public override void unlockDoor(){
        base.unlockDoor();
        Changer.green();
    }
}
