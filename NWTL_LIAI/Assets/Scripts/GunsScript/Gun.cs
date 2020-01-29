using UnityEngine;

public class Gun : MonoBehaviour{
    //Mesh
    public int[] Mesh; 


    //Gun Stats
    public float damage = 10f;
    public float impactForce = 30f;
    public float range = 50f;
    public float fireRate = 50f;
    private WeaponSwitching WeaponHolder;

    private float nextTimeToFire = 0f;
    public bool IsFiring = false;

    public int AmmoByShot;

    public Camera fpsCam;
    // Start is called before the first frame update
    void Start(){
        WeaponHolder = GetComponentInParent<WeaponSwitching>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFiring){
            if (Time.time >= nextTimeToFire){
                IsFiring = false;
            }
        }
    }

    public void Fire(){
        if (Time.time >= nextTimeToFire){
            nextTimeToFire = Time.time + 1f/fireRate;
            Shoot();
            IsFiring = true;
        }
    }
    
    void Shoot(){
        RaycastHit hit;
        
        if (WeaponHolder.Ammo < AmmoByShot)
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


        WeaponHolder.Ammo -= AmmoByShot;

    }

    public void Reload(){
        GetComponentInParent<AmmoProvisoryInventory>().ReloadGun(WeaponHolder);
    }
}
