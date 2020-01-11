using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour{ 
    
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sequence(string id){
        //string s = (string)list[id];
        Debug.Log(id);

        switch (GetBaseManager().getList(id)[0])
        {
            case 0: GetBaseManager().goNextBase(id);
                break;

            default: Debug.Log("non defined option");
                break;
        }

    }

    //getSpawnManager().InvokeRepeating(getSpawnManager().spawnByBase(findBase("base1").GetComponent));

    private SpawnManager GetSpawnManager(){
        return GetComponent<SpawnManager>();
    }

    private BaseManager GetBaseManager(){
        return GetComponent<BaseManager>();
    }
}
