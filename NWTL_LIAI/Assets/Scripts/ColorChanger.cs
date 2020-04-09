using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{       
    List<Material> m = new List<Material>();
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<MeshRenderer>().GetMaterials(m);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void color(float red, float green, float blue){
        m[0].color = new Color(red, green, blue, 1);
    }

    public void green(){
        color(0,1,0);
    }

    public void blue(){
        color(0,0,1);
    }

    public void red(){
       color(1,0,0);
    }

    
}
