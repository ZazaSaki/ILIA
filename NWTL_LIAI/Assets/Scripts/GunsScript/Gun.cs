using UnityEngine;

public class Gun : MonoBehaviour{

    public float damage = 10f;
    public float impactForce = 30f;
    public float range = 50f;
    public float fireRate = 50f;
    public int ammo = 10;
    public int maxAmmo = 10;

    private float nextTimeToFire = 0f;

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start(){
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
        }

    }

    void Shoot(){
        RaycastHit hit;
        
        if (ammo < 1)
        {
            return;
        }
        
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


        ammo--;

    }
}
