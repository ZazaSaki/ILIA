using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSuicidal : EnemieParentScript{   
    
    public GameObject granade;
    bool Exploded = false; 

    public override void attack(){
            base.attack();
            if (!Exploded){
            Exploded = true;
            granade = Instantiate(granade, transform.position, new Quaternion());
            Granade bomb = granade.GetComponent<Granade>();
            bomb.damage = damage;
            bomb.i = 12;
            }
        
    }

    public bool hasExploded(){
        return Exploded;
    }
}

