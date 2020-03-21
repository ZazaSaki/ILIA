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
        m[0].color = Color.green;
    }

    public void blue(){
        m[0].color = Color.blue;
    }

    public void red(){
        m[0].color = Color.red;
    }

    
}
