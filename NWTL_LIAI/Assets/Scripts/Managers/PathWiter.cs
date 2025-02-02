﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PathWiter : MonoBehaviour
{   

    public string[] SetPathList;
    private LinkedList<string> PathList = new LinkedList<string>();
    private LinkedList<string> FileList = new LinkedList<string>();
    private string NextNotification;
    private string Event;
    private string Notification;
    // Start is called before the first frame update
    
    void Start()
    {
        readFile(FileList);

        foreach (string item in FileList)
        {
            read(item);
        }

        Debug.Log("lista/");
        foreach (string item in PathList)
        {
            Debug.Log(item);
        }
        Debug.Log("/lista");

        write();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    public void readFile(LinkedList<string> lista){
        string path = "Assets/Scripts/Managers/StoryScript/Script.txt";
        
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

    public void write(){
        string path = "Assets/Scripts/Managers/StoryScript/Script3.txt";
        
        
        if (!File.Exists(path))
        {   
            string s = "";
            foreach (string item in PathList){
                s += item + "$";
            }

            s = s.Substring(0, s.Length-1);

            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
               sw.WriteLine(s);
            }
        }
        return;
        if (!File.Exists(path))
        {
            // Create a file to write to.
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (string item in PathList){
                    sw.WriteLine(item);
                }
            }
        }
    }

    public void read(string line){
        
        //reading the event info
        string[] info = line.Split('.');

        string type = info[0];
        string id = info[1];

        switch (type)
        {
            case "B":Base(id);
                break;

            case "D": string action = info[2]; 
                Door(id, action); 
                break;

            case "M": Mission(id); 
                break;

            

            
            default: Debug.Log("NAN founded");
                break;
        } 
    }

    public void Base(string id){
        Event = "B."+ id +".G";
        if (NextNotification != null){
            Event = NextNotification + "/" + Event;    
        }

        PathList.AddLast(Event);
        PathList.AddLast("N.B."+ id +".A/B."+ id +".D");
        NextNotification = "N.B."+ id +".R";
        
    }

    public void Door(string id, string action){
        Event = "D."+ id +"." + action;
        if (NextNotification != null){
            Event = NextNotification + "/" + Event;    
        }

        PathList.AddLast(Event);
        NextNotification = "N.D."+ id +"." + action;
        
    }

    public void Mission(string loc){
        Event = "M."+loc+".G";

        if (NextNotification != null){
            Event = NextNotification + "/" + Event;
        }
        PathList.AddLast(Event);

        NextNotification = "N.M."+ loc +".A";
    }
}
