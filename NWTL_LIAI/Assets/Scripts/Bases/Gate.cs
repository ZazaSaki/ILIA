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
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    override public void Action(Transform Player){
        if (Opened)close(); else open();
    }

    public void open(){
        if(Locked)return;
        BodyLock.active = false;
        Opened = true;
    }

    public void close(){
        BodyLock.active = true;
        Opened = false;
    }

    public void lockDoor(){
        Locked = true;
       Changer.red();
        em().Notify("N.D." + id + ".L");
    }

    public void unlockDoor(){
        Locked = false;
        Changer.green();
        em().Notify("N.D." + id + ".U");
    }
}
