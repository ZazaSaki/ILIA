using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseManager : MonoBehaviour
{   
    public Hashtable list = new Hashtable();
    public BaseParent[] BasePathList;
    public BaseParent[] BasePathList2;
    public LinkedList<string> BasePathID = new LinkedList<string>();
    public LinkedListNode<string> CurrentListId;
    public string CurrentBaseID;
    public Transform player;
    
    private string Notification = "N.B.";
    
    
    // Start is called before the first frame update
    void Start()
    {   
        
        //Loading the the baselist ID
        foreach (BaseParent item in BasePathList){
            BasePathID.AddLast(item.id);
        }

        //Loading the first Base
        CurrentListId = BasePathID.First;
        

        
        //inicializating base list
        foreach (BaseParent item in FindObjectsOfType(typeof(BaseParent)))
        {   
            //CHECKING REPEATED BASES
            if (!list.ContainsKey(item.id))
            {   
                list.Add(item.id, new int[3]{0,1,0});

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
        if (CurrentListId.Next != null)
        {   
            CurrentListId = CurrentListId.Next;
            return findBase(CurrentListId.Value);
        }

        return null;
    }

    public void goNextBase(string id){
        resetCurrrentBase();
        BaseParent b = findNextBase(id);
        CurrentBaseID = b.id;

        //getting the transform of the next base
        Transform NextBaseTransform =(b == null) ? null : b.GetComponent<Transform>();
        
        if (b!=null){
            b.unlock();
            Debug.Log("unlock: "+ b.id);
        }

        //setting the compass
        Debug.Log(player.GetComponent<compassChanger>());
        player.GetComponent<compassChanger>().PointTo(NextBaseTransform);

        //notify Event Mabager
        em().Notify(Notification + CurrentBaseID + ".G");
    }

    public void goBase(string id){
        resetCurrrentBase();
        BaseParent b = findBase(id);
        CurrentBaseID = b.id;

        //getting the transform of the next base
        Transform NextBaseTransform =(b == null) ? null : b.GetComponent<Transform>();
        
        if (b!=null){
            b.unlock();
            Debug.Log("unlock: "+ b.id);
        }

        //setting the compass
        Debug.Log("Player Here: " + player.GetComponent<compassChanger>());
        player.GetComponent<compassChanger>().PointTo(NextBaseTransform);

        //notify Event Mabager
        em().Notify(Notification + CurrentBaseID + ".G");
        Debug.Log("BaseManager: " + Notification + CurrentBaseID + ".G");

    }

    public int[] getList(string id){
        return (int[])list[id];
    }

    public int getIncrementedSeq(string id){
        int[] seq = (int[])list[id];
        int i = ++seq[0];
         
         if (i < seq.Length){
             return seq[i];
         }else{
             return 99;
         }
    }

    public void resetCurrrentBase(){
        resetBase(CurrentBaseID);
    }

    public void resetBase(string id){
        if (findBase(id)!=null){
            findBase(id).Reset();
        }
    }

    public EventManager em (){
        return FindObjectOfType<EventManager>();
    }
}
