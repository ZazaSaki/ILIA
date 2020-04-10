using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSuicide : Health
{   
    public GameObject I;
    protected override void Die(){
        EnemieSuicidal e = GetComponentInParent<EnemieSuicidal>();
        if (!e.hasExploded()){
            e.attack();
        }
        
        Destroy(I);
    }
}
