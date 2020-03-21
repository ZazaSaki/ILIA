using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCollorLifeChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColor();
        
    }

    void ChangeColor(){
        List<Material> m = new List<Material>();
        this.GetComponent<MeshRenderer>().GetMaterials(m);
        
        float health = this.GetComponent<Health>().health;
        float maxHealth = this.GetComponent<Health>().maxhealth;
        
        float green = health/maxHealth;
        float red = 1 - green;
        
        Color c = new Color(red,green,0,1);
        
        m[0].color = c;
    }
}
