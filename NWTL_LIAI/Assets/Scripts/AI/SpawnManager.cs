using UnityEngine;
using UnityEngine.AI;

public class SpawnManager : MonoBehaviour{

    public SpawnInfo[] List;
    public NavMeshSurface nav;
    public GameObject AI_Tester;

    // Start is called before the first frame update
    private void spawn(Vector3 spawnLoc){
        spawnLoc = nav.navMeshData.sourceBounds.ClosestPoint(spawnLoc);
        Instantiate(AI_Tester, spawnLoc,  new Quaternion());
        
        
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
