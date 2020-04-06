using System.Collections;
using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour{ 
    
    public GameObject DebugPoint;
    public bool[] EspecialSeq;
    public Transform player;
    private Boolean Special = false;
    private LinkedList<bool> SpecialEvents = new LinkedList<bool>();
    private LinkedListNode<bool> CurrentSpecial = new LinkedListNode<bool>(false);

    float rate;
    string id;

    // Start is called before the first frame update
    void Start()
    {
        //FindObjectOfType<PlayerMovement>().GetComponent<compassChanger>().PointTo(GetBaseManager().findBase("base1").GetComponent<Transform>());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sequence(string id){
        
        return;
        
        //string s = (string)list[id];
        Debug.Log(id);
        this.id = id;
        rate = 5;
        
        if (GetBaseManager().findBase(id).EspecialSeq || Special){
            Special = true;
            SpecialSequence();
            return;
        }

        GetBaseManager().goNextBase(id);
        return;

        switch (GetBaseManager().getIncrementedSeq(id))
        {
            case 0: GetBaseManager().goNextBase(id);
                break;

            case 1: SpawnRepeat();
                break;
            
            default: GetBaseManager().findBase(id).Reset();
                Debug.Log("non defined option");
                break;
        }

    }


    public void SpecialSequence(){
        
        if (Special & CurrentSpecial.Next != null)
        {
            CurrentSpecial = CurrentSpecial.Next;
        }

        Special = CurrentSpecial.Value;

    }
    //getSpawnManager().InvokeRepeating(getSpawnManager().spawnByBase(findBase("base1").GetComponent));

    public void SpawnRepeat(){
        Vector3 loc = GetBaseManager().findBase(id).GetComponent<Transform>().position;
        Debug.Log(loc);
        GetSpawnManager().spawnByBaseInvoke(loc, 30, 3, 6, 3);
    }

    private SpawnManager GetSpawnManager(){
        return GetComponent<SpawnManager>();
    }

    private BaseManager GetBaseManager(){
        return GetComponent<BaseManager>();
    }

    public void resetBase(){
        GetBaseManager().resetCurrrentBase();
    }
    
}
