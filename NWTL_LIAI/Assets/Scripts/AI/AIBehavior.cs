
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour{   

    public NavMeshAgent Agent;
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
    Vector3 Target;


//Behavior
    
    // Update is called once per frame
    void Update()
    {
        FindPlayer();
        if (IsDetected()){
            Target = playerLoc;
            ChasePlayer();

            //Chenking atack
            if (IsInRange){
                attack();
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
        
        
    }

    public void FindActiveBase(){
        
    }

    public bool IsDetected(){
        DetectionStats stats = GetComponent<DetectionStats>();
        
        //checking Player Distance
        float distance = (playerLoc - GetComponent<Transform>().position).magnitude;
       
        //Checking if player is in range
        IsInRange = GetEnemieParentScript().attackRange > distance;
       
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
    

    public void ChasePlayer(){
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
}
