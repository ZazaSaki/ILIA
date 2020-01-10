﻿
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour{   

    //Debug var
    public float DebugDistance;


    //Public var
    public NavMeshAgent Agent;
    public float SecureDistance;
    public bool MealeDamage;
//Black Board
    
    //Player Stats
    Vector3 playerLoc;
    bool playerIsFiring = false;
    bool playerIsRunning = false;
    bool playerIsMoving = false;

    
    //Base Stats
    Vector3 baseLoc;
    bool baseIsActive = false;

    
    //Target Stats
    bool IsInRange = false;
    bool IsInSecureRange = false;
    Vector3 Target;
    float distanceToSecureAttack;


//Behavior
    
    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        if (FindActiveBase()){
            ChaseTarget();
        
        
        }else if (IsPlayerDetected()){
            
            ChaseTarget();

            //Chenking atack
            if (IsInRange){
                //Verify if player is moving, and attack if player is stoped
                if (!playerIsMoving){
                    distanceToSecureAttack = 0;
                
                //if player is moving, get close and attack until is out of range
                }else if (IsInSecureRange){
                    distanceToSecureAttack = 0;
                    attack();
                }
            //randomize the secure distance to attack
            }else if(MealeDamage){
                distanceToSecureAttack = getRandom(SecureDistance);
            }
            
        }
        
    }

    public void FindPlayer(){
        //player Refrence
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        
        //Updating Player Status
        playerIsMoving = playerLoc == FindObjectOfType<PlayerMovement>().GetComponent<Transform>().position;
        playerIsFiring = player.GetComponentInChildren<WeaponSwitching>().GetActualGun().IsFiring;
        playerIsRunning = player.IsRunning;

        //updating player Location
        playerLoc = FindObjectOfType<PlayerMovement>().GetComponent<Transform>().position;
        
        //setting player as a target
        Target = playerLoc;
    }

    public bool FindActiveBase(){
        float distance = 0;
        float closest = 0;
        bool ret = false;

        BaseParent[] baseList = FindObjectsOfType<BaseParent>();

        if (baseList.Length == 0){
            return false;
        }

        //closest : first value
        closest = (baseList[0].GetComponent<Transform>().position - GetTransform().position).magnitude;

        foreach (BaseParent item in baseList){
            distance = (item.GetComponent<Transform>().position - GetTransform().position).magnitude;
            
            
            if(closest > distance && item.IsActive){
                ret = true;
                
                //setting base as a target
                Target = item.GetComponent<Transform>().position;
            }
            
        }
        return ret;
    }

    public bool IsPlayerDetected(){
        DetectionStats stats = GetComponent<DetectionStats>();
        
        //checking Player Distance
        float distance = (playerLoc - GetComponent<Transform>().position).magnitude;

        DebugDistance = distance;

        //Checking if player is in range
        IsInRange = GetEnemieParentScript().attackRange > distance;
        
        //Calculate if player is close enough to do a sucessfull attack
        IsInSecureRange = (MealeDamage ? true : (GetEnemieParentScript().attackRange - distanceToSecureAttack > distance));
       
        //Checking Player Detection
        if (distance < stats.FireRange){
            if (playerIsFiring) return true;

            if (distance < stats.RunRange){
                if (playerIsRunning) return true;

                if (distance < stats.WalckRange)return true;
            }
        }
        return false;
    }
    

    public void ChaseTarget(){
        Agent.SetDestination(Target);
    }

    public void attack(){
        GetEnemieParentScript().attack();
    }

    public EnemieParentScript GetEnemieParentScript(){
        return GetComponent<EnemieParentScript>();
    }

    public Transform GetTransform(){
        return GetComponent<Transform>();
    }

    public float getRandom(float max){
        float rand = (float)(new System.Random().NextDouble());

        return rand * (max);
    }
}
