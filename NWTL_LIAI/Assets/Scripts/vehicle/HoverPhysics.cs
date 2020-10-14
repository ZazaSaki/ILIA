using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverPhysics : MonoBehaviour
{   

    //hover vars
    public float hoverForce;
    public Transform[] hoverPoints = new Transform[4];
    public RaycastHit[] hoverRays = new RaycastHit[4];
    Rigidbody rb;


    //motor vars
    private float usableForce = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hoverPoints.Length; i++)
        {
            ApplyHoverForce(hoverPoints[i], hoverRays[i]);
        }
    }

    private float CalculateHoverForce(Transform hoverPoint, RaycastHit hoverRay){
        if (Physics.Raycast(hoverPoint.position, -hoverPoint.up, out hoverRay)){
            
            //Force multiplier value per HoverPoint
            float multiplier = (1/(Mathf.Abs(hoverRay.point.y - hoverPoint.position.y)))/hoverPoints.Length;
            return multiplier*hoverForce;
            //aplying force
            
        }

        return 0;
    }

    private void ApplyHoverForce(Transform hoverPoint, RaycastHit hoverRay){
        usableForce = CalculateHoverForce(hoverPoint, hoverRay);
        
        rb.AddForceAtPosition(hoverPoint.up*usableForce, hoverPoint.position, ForceMode.Acceleration);
    }
}
