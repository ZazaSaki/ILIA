
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour{   

    public NavMeshAgent Agent;
//Black Board
    //Player vars
    Vector3 playerLoc;
    bool playerIsFiring;
    bool playerIsRunning;

    //Base vars
    Vector3 baseLoc;
    bool baseIsActive;


//Behavior
    
    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        ChasePlayer();
    }

    public void FindPlayer(){
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        
        
        playerLoc = FindObjectOfType<PlayerMovement>().GetComponent<Transform>().position;
        playerIsFiring = player.GetComponentInChildren<WeaponSwitching>().GetActualGun().IsFiring;
        playerIsRunning = player.IsRunning;


        Debug.Log("Player Found : " + playerLoc);
        Debug.Log("Is firing : "+ playerIsFiring);
    }

    public void FindActiveBase(){
        
    }

    public bool IsDetected(){
        if (true)
        {
            
        }
        return false;
    }

    public void ChasePlayer(){
        Agent.SetDestination(playerLoc);
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
}
