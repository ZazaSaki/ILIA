using System.Collections;
using System;
using UnityEngine;
using UnityEngine.AI;

public class GameMaster : MonoBehaviour{
    public NavMeshSurface nav;
    public GameObject AI_Tester;   
    public Hashtable list = new Hashtable();
    string[] BasePath = {"base1", "base2", "base3"};
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        



        //inicializating base list
        foreach (BaseParent item in FindObjectsOfType(typeof(BaseParent)))
        {   
            //CHECKING REPEATED BASES
            if (!list.ContainsKey(item.id))
            {   
                list.Add(item.id, new int[2]{0,1});

                Debug.Log(item.id);
            }else{
                Debug.Log("repeated ID " + item.id);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void sequence(string id){
        //string s = (string)list[id];
        Debug.Log(id);
        findBase(id);

        switch (((int[])list[id])[0])
        {
            case 0: goNextBase(id);
                break;

            default: Debug.Log("non defined option");
                break;
        }

    }

    private void spawn(Vector3 spawnLoc){
        
        Instantiate(AI_Tester, new Vector3(3, 3 ,3),  new Quaternion());
        
        spawnLoc = nav.navMeshData.sourceBounds.ClosestPoint(spawnLoc);
    }

    public void spawnByBase(Vector3 BaseLoc, float BaseRay){
        System.Random rand = new System.Random();
        
        
        float r = (float)rand.NextDouble();
        r = r * 10f + BaseRay; 

        float x = rand.NextDouble() > 0.5 ? ((float)rand.NextDouble() * r) : ((float)rand.NextDouble() * r) * -1;

        float y = rand.NextDouble() > 0.5 ? (float)Math.Sqrt((r*r - x*x))  : (float)Math.Sqrt((r*r - x*x)) * -1;

        spawn(new Vector3(x, BaseLoc.y , y));
    }

    private BaseParent findBase(string id){
        BaseParent output = null;

        //searching in every base
        foreach (BaseParent item in FindObjectsOfType<BaseParent>())
        {   
            //cheking the wanted id
            if (item.id.Equals(id)){
                output = item;
                Debug.Log("Base ID founded: " + output.id);
                return output;
            }
        }

        //notifing about the non existing id
        if (output == null){
            Debug.Log("item not founded");
        }


        return output;
    }

    private BaseParent findNextBase(string id){
        int i = 0;
        
        //Search in BasePath
        foreach (string item in BasePath){
            if (item.Equals(id)){
                //retunning next base
                if (i+1<BasePath.Length)
                    return findBase(BasePath[++i]);
                else
                    Debug.Log("No More Bases");

            }
            i++;
        }

        return null;
    }

    private void goNextBase(string id){
        BaseParent b = findNextBase(id);
        Debug.Log("This base: " + id);
        Debug.Log("Next Base: " + b.id);
        Debug.Log("Next Base Transform: " + b.GetComponent<Transform>());
        //getting the transform of the next base
        Transform NextBaseTransform =(b == null) ? null : b.GetComponent<Transform>();
        
        Debug.Log("Checking Last: " + NextBaseTransform);
        
        //setting the compass

        Debug.Log(player.GetComponent<compassChanger>());
        player.GetComponent<compassChanger>().PointTo(NextBaseTransform);
    }
}
