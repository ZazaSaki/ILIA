using UnityEngine;

public class Gun : GunParent{

    //Gun Stats
    public float damage = 10f;
    public float impactForce = 30f;
    public float range = 50f;
    
    
    public override void Shoot(){
        RaycastHit hit;
        
        //RayCast
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)){

            Health targetComp = hit.transform.GetComponent<Health>();

            //aplying damage an force
            if (targetComp != null){
                targetComp.TakeDamage(damage);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal*impactForce);
            }
        }


        decreaseAmmo();

    }

    
}
