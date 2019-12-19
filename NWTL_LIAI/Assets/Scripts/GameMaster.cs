using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{   
    public Hashtable list = new Hashtable();

    // Start is called before the first frame update
    void Start()
    {
        foreach (BaseParent item in FindObjectsOfType(typeof(BaseParent)))
        {
            if (!list.ContainsKey(item.id))
            {
                list.Add(item.id, "empty");

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
}
