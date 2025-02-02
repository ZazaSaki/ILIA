﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour{   


    public GameObject ExplosionEffect;
    public GameObject Body;
    public float explosionForce = 700f;
    public float radius = 10f   ;
    public float delay = 3f;
    float countdown;
    bool hasExploded = false;
    GameObject tempEffect;
    public float damage;
    public int i = 1;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;
    }

    // Update is called once per frame
    void Update()
    {
        countdown -= Time.deltaTime * i;

        if (countdown <= 0 && !hasExploded){
            hasExploded = true;
            Explode();
        }

        if (countdown <= 0 && hasExploded){
            Destroy(tempEffect);
            //Destroy Granade
            Debug.Log("destroyed");
            Destroy(tempEffect);
            Destroy(gameObject);
            Debug.Log("desrrrrrrrrrrr");
        }

        
    }

    public void setCountDown(float time){
        countdown = time;
    }

    public void Explode(){
        i = 1;
        Destroy(Body);
        //Show effect
        tempEffect = Instantiate(ExplosionEffect, transform.position, transform.rotation);
        ParticleSystem part = tempEffect.GetComponent<ParticleSystem>();
        part.loop = false;
        countdown = part.duration;

        //Find all nearby objects
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider nearbyObject in colliders){
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                
                //aply forces
                if (rb != null){
                    rb.AddExplosionForce(explosionForce, transform.position, radius);
                }
                //aply damage
                Health h = nearbyObject.GetComponent<Health>();
                if (h!=null)
                {
                    h.TakeDamage(damage);
                }
                
            }
    }
}
