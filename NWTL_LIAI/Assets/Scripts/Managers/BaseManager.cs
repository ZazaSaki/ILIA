using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{   
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

    public BaseParent findBase(string id){
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


    public BaseParent findNextBase(string id){
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

    public void goNextBase(string id){
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

    public int[] getList(string id){
        return (int[])list[id];
    }
}
