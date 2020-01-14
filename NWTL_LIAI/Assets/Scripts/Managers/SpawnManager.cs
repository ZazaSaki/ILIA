using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour{
    
    private bool Spawning;
    private int NumOfSpawns;
    private int SpawnLevel;
    private EnemieParentScript.Type SpawnType;
    public GameObject[] List;
    public NavMeshSurface nav;
    public GameObject ObjectToSpawn;

    public Transform DebugPoint;
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
    

    //Spawn By Position inside the nav mesh
    public void spawn(Vector3 spawnLoc){
        spawnLoc = nav.navMeshData.sourceBounds.ClosestPoint(spawnLoc);
        Instantiate(ObjectToSpawn, spawnLoc,  new Quaternion());
        
        
    }

    public void spawnByBase(Vector3 BaseLoc, float BaseRay, int maxEnemiesAtOnce, int EnemiesToSpawn){
        float SpawnRange = 20;
        //Start Counting the spawns
        if (!Spawning)
        {
            Spawning = true;
            NumOfSpawns = EnemiesToSpawn;
        }
        
        //Random object to generate Random numbers (double)
        System.Random rand = new System.Random();
        
        
//Generate random x and y, with a r distance from the base
    //Generating the r
        //random num between:  0 and 1
        float r = (float)rand.NextDouble();
        //Getting a r bettween : BaseRay and (BaseRay + SpawnRange)
        r = r*(SpawnRange) + BaseRay;

    //Generating the x
        //generating random x between : 0 and (SpawnRange + BaseRay)
        float x = (SpawnRange + BaseRay) * (float)rand.NextDouble();
        //adding x to the center 
        x = rand.NextDouble() > 0.5 ? (BaseLoc.x - r) : (BaseLoc.x + r);

    //Generating the y    
    //y = sqrt(r^2 - (x-a)^2) + b; {a,b} = Center 
        //calculating the square root part
        float Sqrt = (float)System.Math.Sqrt(r*r - ((x-BaseLoc.x)*(x-BaseLoc.x)));
        //Adding b
        float y = rand.NextDouble() > 0.5 ? BaseLoc.z + Sqrt : BaseLoc.z - Sqrt;
        
        Debug.Log("y: " + y + "; r: " + r + "; x: " + x + "; a: " + BaseLoc.x);
        
        //checking the number of enemies
        if (FindObjectsOfType<EnemieParentScript>().Length < maxEnemiesAtOnce){
           
           Debug.Log("vector : " + new Vector3(BaseLoc.x - x, BaseLoc.y , BaseLoc.z - y));

           spawn(new Vector3(BaseLoc.x - x, BaseLoc.y , BaseLoc.z - y)); 
           NumOfSpawns--;

           //chencking the number of spawned enemies
           if (NumOfSpawns < 1)
           {
               StopSpawning();
           }
        }
    }

    public void StopSpawning(){
        //Stop Calling the Spawn Function
        GetComponent<GameMaster>().CancelInvoke();
        
        //reset Base to the next Event
        GetComponent<GameMaster>().resetBase();
        
        //reset The Spanw Counter
        Spawning = false;
    }
    

    
}
