using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;
    public float maxFallHeight = 4f;
    public float multipier = 1f;
    
    public Transform groundCheck;
    public LayerMask groundMask;
    
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start(){
        jumpHeight = jumpHeight * multipier;
        maxFallHeight = maxFallHeight * multipier;
        gravity = gravity * Mathf.Sqrt(multipier);
    }

    // Update is called once per frame
    void Update(){

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);
        if (isGrounded && velocity.y < 0){
            if (velocity.y < -Mathf.Sqrt(maxFallHeight * -2f *gravity)){
                Debug.Log("DamageFall");
                controller.GetComponent<Health>().TakeDamage(30);
            }
            velocity.y = -2f;
            Debug.Log(isGrounded);
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetButtonDown("Jump") && isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
