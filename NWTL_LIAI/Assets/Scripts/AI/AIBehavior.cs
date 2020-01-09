
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
        IsDetected();
        //ChasePlayer();
    }

    public void FindPlayer(){
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        
        
        playerLoc = FindObjectOfType<PlayerMovement>().GetComponent<Transform>().position;
        playerIsFiring = player.GetComponentInChildren<WeaponSwitching>().GetActualGun().IsFiring;
        playerIsRunning = player.IsRunning;
    }

    public void FindActiveBase(){
        
    }

    public bool IsDetected(){
        DetectionStats stats = GetComponent<DetectionStats>();
        float distance = (playerLoc - GetComponent<Transform>().position).magnitude;
        
        if (distance < stats.FireRange){
            if (playerIsFiring) return true;

            if (distance < stats.RunRange){
                if (playerIsRunning) return true;

                if (distance < stats.WalckRange)return true;
            }
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
