using System.Collections;
using System.Collections.Generic;
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
    void Start()
    {
        //Filling the event List
        foreach (string item in SetEventList){
            InfoList.AddLast(item);
        }
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
            
            case "D": Debug.Log("Defend");
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
            case "L": getDoorManager().lockDoor(id);
                break;
            
            case "U": getDoorManager().unlockDoor(id);
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

            case "D": Debug.Log("D founded"); 
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

    public DoorManager getDoorManager(){
        return FindObjectOfType<DoorManager>();
    }
}
