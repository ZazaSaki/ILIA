﻿using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour{ 
    
    public GameObject DebugPoint;
    public Transform player;

    float rate;
    string id;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PlayerMovement>().GetComponent<compassChanger>().PointTo(GetBaseManager().findBase("base1").GetComponent<Transform>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sequence(string id){
        //string s = (string)list[id];
        Debug.Log(id);
        this.id = id;
        rate = 5;
        int i = GetBaseManager().getIncrementedList(id)[0];

        switch (GetBaseManager().getList(id)[i])
        {
            case 0: GetBaseManager().goNextBase(id);
                break;

            case 1: InvokeRepeating("SpawnRepeat", rate, rate);
                break;
            
            default: Debug.Log("non defined option");
                break;
        }

    }

    //getSpawnManager().InvokeRepeating(getSpawnManager().spawnByBase(findBase("base1").GetComponent));

    public void SpawnRepeat(){
        Vector3 loc = GetBaseManager().findBase(id).GetComponent<Transform>().position;
        
        GetSpawnManager().spawnByBase(loc, 20, 3, 6);
    }

    private SpawnManager GetSpawnManager(){
        return GetComponent<SpawnManager>();
    }

    private BaseManager GetBaseManager(){
        return GetComponent<BaseManager>();
    }

    public void resetBase(){
        GetBaseManager().findBase(id).Reset();
    }
}
