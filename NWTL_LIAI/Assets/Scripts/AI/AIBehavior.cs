
using UnityEngine;
using UnityEngine.AI;

public class AIBehavior : MonoBehaviour{   

    //Debug var
    public float TargetDistance;


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
        
        Target = playerLoc;
        
        if (FindActiveBase()){
            ChaseTarget();
            CheckTargeDistance();
            if (IsInRange){
                attack();
            }
        
        }
        
        if (IsPlayerDetected() && setTarget(playerLoc)){
            
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
    }

    public bool FindActiveBase(){
        bool ret = false;

        BaseParent[] baseList = FindObjectsOfType<BaseParent>();
        
        //if there are no bases
        if (baseList.Length == 0){
            return false;
        }

        //closest : first value
        foreach (BaseParent item in baseList){
            
            if(item.IsActive){
                if (setTarget(item.GetComponent<Transform>().position))
                {
                    ret = true;
                }
                
                //Debug.Log("is Base active : " + gameObject);
            }
            
        }
        return ret;
    }

    public float CheckTargeDistance(){
        //checking Player Distance
        float distance = (Target - GetComponent<Transform>().position).magnitude;

        TargetDistance = distance;

        //Checking if player is in range
        IsInRange = GetEnemieParentScript().attackRange > distance;
        Debug.Log("Range" + IsInRange);
        
        //Calculate if player is close enough to do a sucessfull attack
        IsInSecureRange = (MealeDamage || (playerLoc != Target) ? true : (GetEnemieParentScript().attackRange - distanceToSecureAttack > distance));
    
        return distance;
    }

    public bool setTarget(Vector3 Location){
        float distance = (Location - GetTransform().position).magnitude;
        
        if ((TargetDistance >= distance) || !IsPlayerDetected()){
            Target = Location;
            TargetDistance = distance;
            return true;
        }

        return false;   
    }

    public bool IsPlayerDetected(){
        DetectionStats stats = GetComponent<DetectionStats>();
        
        //checking Player Distance
        float distance = CheckTargeDistance();
       
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
        
        //Debug.Log(Target);
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
