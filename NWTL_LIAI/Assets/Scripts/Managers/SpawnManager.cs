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


    //invoke vars:
    private Vector3 BaseLocInv;
    private float BaseRayInv;
    private int maxEnemiesAtOnceInv;
    private int EnemiesToSpawnInv;
    private Transform[] SpawnPointsInv;



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
    private void spawn(Vector3 spawnLoc){
        Vector3 newSpawnLoc = nav.navMeshData.sourceBounds.ClosestPoint(spawnLoc);
        Instantiate(ObjectToSpawn, newSpawnLoc,  new Quaternion());
        
        
    }

    public void spawnByBase(){
        float SpawnRange = 20;
        //Start Counting the spawns
        StartSpawning();
        
        //Random object to generate Random numbers (double)
        System.Random rand = new System.Random();
        
        
//Generate random x and y, with a r distance from the base
    //Generating the r
        //random num between:  0 and 1
        float r = (float)rand.NextDouble();
        //Getting a r bettween : BaseRay and (BaseRay + SpawnRange)
        r = r*(SpawnRange) + BaseRayInv;

    //Generating the x
        //generating random x between : 0 and (SpawnRange + BaseRay)
        float x = r * (float)rand.NextDouble();
        //adding x to the center 
        x = rand.NextDouble() > 0.5 ? (BaseLocInv.x - x) : (BaseLocInv.x + x);

    //Generating the y    
    //y = sqrt(r^2 - (x-a)^2) + b; {a,b} = Center 
        //calculating the square root part
        float Sqrt = (float)System.Math.Sqrt(r*r - ((x-BaseLocInv.x)*(x-BaseLocInv.x)));
        //Adding b
        float y = rand.NextDouble() > 0.5 ? BaseLocInv.z + Sqrt : BaseLocInv.z - Sqrt;
        
        
        /////////////////////////////////////////////////
        Debug.Log( "Sqrt(" + r + "*" + r + "-" + "((" + x + "-" + BaseLocInv.x + ")*(" + x + "-" + BaseLocInv.x + "))) = " + System.Math.Sqrt(r*r - ((x-BaseLocInv.x)*(x-BaseLocInv.x))));
        Debug.Log("y: " + y + "; r: " + r + "; x: " + x + "; a: " + BaseLocInv.x);
            ////////////////////////////////

        
        //checking the number of enemies
        if (FindObjectsOfType<EnemieParentScript>().Length < maxEnemiesAtOnceInv){
           
           ////////////////////////////
           Debug.Log("vector Base z : " + BaseLocInv.z);
           Debug.Log("vector y : " + y);
           Debug.Log("vector : " + new Vector3(BaseLocInv.x - x, BaseLocInv.y , BaseLocInv.z - y));
            ///////////////////////////////////

           spawn(new Vector3(BaseLocInv.x - x, BaseLocInv.y , BaseLocInv.z - y)); 
           NumOfSpawns--;

           //chencking the number of spawned enemies
           if (NumOfSpawns < 1)
           {
               StopSpawning();
           }
        }
    }

    public void spawnByBaseInvoke(Vector3 BaseLoc, float BaseRay, int maxEnemiesAtOnce, int EnemiesToSpawn, float rate){
        BaseLocInv = BaseLoc; 
        BaseRayInv = BaseRay;
        maxEnemiesAtOnceInv = maxEnemiesAtOnce;
        EnemiesToSpawnInv = EnemiesToSpawn;
        InvokeRepeating("spawnByBase", rate, rate);
    }

    public void spawnByBaseFixed(){
        StartSpawning(); 

        System.Random rand = new System.Random();
        
        int r = (int)(rand.NextDouble() * SpawnPointsInv.Length);
        
        spawn(SpawnPointsInv[r].position); 
        NumOfSpawns--;

        //chencking the number of spawned enemies
        if (NumOfSpawns < 1)
        {
            StopSpawning();
        }
        
        
    }

    public void spawnByBaseInvokeFixed(Transform[] points, int maxEnemiesAtOnce, int EnemiesToSpawn, float rate){
        SpawnPointsInv = points;
        maxEnemiesAtOnceInv = maxEnemiesAtOnce;
        EnemiesToSpawnInv = EnemiesToSpawn;
        InvokeRepeating("spawnByBaseFixed", rate, rate);
    }

    public void StartSpawning(){
        if (!Spawning)
        {
            Spawning = true;
            NumOfSpawns = EnemiesToSpawnInv;
        }
    }

    public void StopSpawning(){
        //Stop Calling the Spawn Function
        CancelInvoke();
        
        //reset Base to the next Event
        GetComponent<BaseManager>().resetCurrrentBase();
        
        //reset The Spanw Counter
        Spawning = false;
    }
    

    
}
