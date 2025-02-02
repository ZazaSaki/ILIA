﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EventManager : MonoBehaviour
{   
    public string[] SetEventList;
    public compassChanger PlayerCompass;
    public GameObject ArrivingChecker;
    private LinkedList<string> InfoList = new LinkedList<string>();
    private LinkedListNode<string> CurrentInfo;
    private LinkedList<string> NotificationList = new LinkedList<string>();
    bool wait = false;

    
    
    // Start is called before the first frame update
    void Start(){   
        readFile(InfoList);

        /*
        //Filling the event List
        foreach (string item in SetEventList){
            InfoList.AddLast(item);
        }
        */
        CurrentInfo = InfoList.First;
        
        //trigerring the first event
        Event(CurrentInfo.Value);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NotificationList.First != null && !wait)
        {
            Notify();
        }
    }

    public void Notify(string info){
        NotificationList.AddLast(info);
    }

    public void Notify(){
        wait = true;
        
        string info = NotificationList.First.Value;
        NotificationList.RemoveFirst();
        //Cheking if next event exists
        if (CurrentInfo == null){
            Debug.Log("No more events");
            return; 
        } 
        
        Debug.Log("While notify " + CurrentInfo.Value);
        
        //Reading the event and the notification required
        string Notification = CurrentInfo.Value.Split('/')[0];
        string EventInfo = CurrentInfo.Value.Split('/')[1];
        
        Debug.Log("Notification: " + Notification);
        Debug.Log("Event: " + EventInfo);

        //Checking the recieved notification
        if (Notification.Equals(info)){
            //Triggering the event
            Event(EventInfo);
        }
        wait = false;
    }

    public void audio(string id, string action){

    }

    public void video(string id, string action){

    }

    public void Mission(string id, string action){
        switch (action)
        {
            case "G": Vector3 loc = getLoc(id); 
                PlayerCompass.PointTo(loc);
                Notify("N.M." + id + ".G");
                Instantiate(ArrivingChecker, loc, new Quaternion());
                break;
            
            case "U": getDoorManager().unlockDoor(id);
                break;
            
            default: Debug.Log("No Action defined");
                break;
        }
    }

    private Vector3 getLoc(string id){
        Debug.Log("get loc : " + id);
        
        string[] vectorInfo = id.Split(',');
        float[] vectorParams = new float[3];
        
        float x = float.Parse(vectorInfo[0]);
        float y = float.Parse(vectorInfo[1]);
        float z = float.Parse(vectorInfo[2]);
        

        
        return new Vector3(x, y, z);
    }

    public void Base(string id, string action){
        Debug.Log("Base :" + id);
        switch (action)
        {
            case "G": getBaseManager().goBase(id);
                break;
            
            case "D": Vector3 loc = getBaseManager().findBase(id).GetComponent<Transform>().position;
                Debug.Log(loc);
                Transform[] temp = getBaseManager().findBase(id).SpawnPointList;
                getSpawnManager().spawnByBaseInvokeFixed(temp, 3,6,1);
                break;

            case "R": getBaseManager().resetCurrrentBase();
                break;
            
            default: Debug.Log("No Action defined");
                break;
        }
        
        
    }

    public void Door(string id, string action){
        
        switch (action)
        {
            case "L": getDoorManager().lockGate(id);
                break;
            
            case "U": getDoorManager().unlockDoor(id);
                break;

            case "LAG": Debug.Log("Lag in event m");
                getDoorManager().lockAllGates();
                break;
            
            default: Debug.Log("No Action defined");
                break;
        }
        
        
    }

    private void Event(string e){
        //
        CurrentInfo = CurrentInfo.Next;
        
        //reading the event info
        string[] info = e.Split('.');

        string type = info[0];
        string id = info[1];
        string action = info[2];

        //selection the events
        switch (type)
        {
            case "B":Base(id, action);
                break;

            case "D": Door(id, action); 
                break;

            case "M": Mission(id, action); 
                break;

            case "A": audio(id, action); 
                break;

            case "V": video(id, action); 
                break;

            
            default: Debug.Log("NAN founded");
                break;
        } 
    }

    public BaseManager getBaseManager(){
        return FindObjectOfType<BaseManager>();
    }

    public GateManager getDoorManager(){
        return FindObjectOfType<GateManager>();
    }

    public SpawnManager getSpawnManager(){
        return FindObjectOfType<SpawnManager>();
    }

    public void readFile(LinkedList<string> lista){
        string path = "Assets/Scripts/Managers/StoryScript/Script2.txt";
        
        string s1 = "B.A.G$N.B.A.A/B.A.D$N.B.A.R/D.AB.U$N.D.AB.U/B.B.G$N.B.B.A/B.B.D$N.B.B.R/D.BC.U$N.D.BC.U/D.BF.U$N.D.BF.U/B.C.G$N.B.C.A/B.C.D$N.B.C.R/D.CG.U$N.D.CG.U/D.AE.U$N.D.AE.U/M.110,1,99.G$N.M.110,1,99.A/B.A.G$N.B.A.A/B.A.D$N.B.A.R/D.AD.U$N.D.AD.U/D.CD.U$N.D.CD.U/B.D.G$N.B.D.A/B.D.D$N.B.D.R/D.EH.U$N.D.EH.U/B.E.G$N.B.E.A/B.E.D$N.B.E.R/D.EI.U$N.D.EI.U/M.177,1,18.G";

        string[] temp = s1.Split('$');

        foreach (string item in temp)
        {
            lista.AddLast(item);
        }

        return;
        using (StreamReader sr = File.OpenText(path))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {   
                if (s.Equals("*")){break;}
                Debug.Log(s);
                lista.AddLast(s);
                Debug.Log("Setted");
            }
        }
    }

}
