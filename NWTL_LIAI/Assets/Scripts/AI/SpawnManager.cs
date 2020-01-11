﻿using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour{
    private int SpawnLevel;
    private EnemieParentScript.Type SpawnType;
    public GameObject[] List;
    public NavMeshSurface nav;
    GameObject ObjectToSpawn;

    // Start is called before the first frame update
    private void Start() {
        foreach (GameObject item in List)
        {
            if(item.GetComponent<EnemieParentScript>()==null)
                Debug.Log("There Is A Non Enemie Game Object In The Spawn List");
        }

        
    }
    
    
    public void CalculateEnemie(float Level1Prob, float Level2Prob, float TypeFastprb, float TypeBalancedProb){
        System.Random rand = new System.Random();
        float prob = (float)rand.NextDouble() * 100f;
        
        //Generating Level
        if (prob <= Level1Prob){
            SpawnLevel = 1;
        }else if (prob <= Level2Prob + Level1Prob){
            SpawnLevel = 2;
        }else{
            SpawnLevel = 3;
        }

        //Generating Type
        prob = (float)rand.NextDouble();
        
        if (prob <= TypeFastprb){
            SpawnType = EnemieParentScript.Type.Fast;
        }else if (prob <= TypeFastprb + TypeBalancedProb){
            SpawnType = EnemieParentScript.Type.Balanced;
        }else{
            SpawnType = EnemieParentScript.Type.Thank;
        }


        //Search for the game object with the correct stats
        foreach (GameObject item in List)
        {
            if(item.GetComponent<EnemieParentScript>().checkedStats(SpawnLevel, SpawnType)){
                ObjectToSpawn = item;
            }else
            {
                CalculateEnemie(Level1Prob, Level2Prob, TypeFastprb, TypeBalancedProb);
            }
        }
    }
    
    private void spawn(Vector3 spawnLoc){
        spawnLoc = nav.navMeshData.sourceBounds.ClosestPoint(spawnLoc);
        Instantiate(ObjectToSpawn, spawnLoc,  new Quaternion());
        
        
    }

    public void spawnByBase(Vector3 BaseLoc, float BaseRay){
        System.Random rand = new System.Random();
        
        
        float r = (float)rand.NextDouble();
        r = r * 10f + BaseRay; 

        float x = rand.NextDouble() > 0.5 ? ((float)rand.NextDouble() * r) : ((float)rand.NextDouble() * r) * -1;

        float y = rand.NextDouble() > 0.5 ? (float)System.Math.Sqrt((r*r - x*x))  : (float)System.Math.Sqrt((r*r - x*x)) * -1;

        spawn(new Vector3(x, BaseLoc.y , y));


    }
    

    
}
