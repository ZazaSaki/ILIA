using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMovable{

    public CharacterController controller;
    public float speed;
    public float walkSpeed = 6f;
    public float RunSpeed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 2f;
    public float maxFallHeight = 4f;
    public float multipier = 1f;
    
    public Transform groundCheck;
    public LayerMask groundMask;

    public bool IsRunning = false;
    
    Vector3 velocity;
    bool isGrounded;

    // Start is called before the first frame update
    void Start(){
        selfAssin(GetComponentInParent<KeyHandler>());
        speed = walkSpeed;
        
        jumpHeight = jumpHeight * multipier;
        maxFallHeight = maxFallHeight * multipier;
        gravity = gravity * Mathf.Sqrt(multipier);
    }

    // Update is called once per frame
    void Update(){
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        
        if (isGrounded && velocity.y < 0){
            
            //Chencking Fall Damage
            if (velocity.y < -Mathf.Sqrt(maxFallHeight * -2f *gravity)){
                Debug.Log("DamageFall");
                controller.GetComponent<Health>().TakeDamage(30);
            }
            
            //Default force on ground
            velocity.y = -2f;
            
        }

        //adding gravity Force
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    public void jump(){
        if (isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void SelfMove(float HorizontalAxis, float VerticalAxis){
        
        Vector3 move = transform.right * HorizontalAxis + transform.forward * VerticalAxis;

        controller.Move(move * speed * Time.deltaTime);
    }

    public void sprint(){
        speed = RunSpeed;
    }
    
    public void walk(){
        speed = walkSpeed;
    }

    public void selfAssin(KeyHandler kh)
    {
        Debug.Log("adding");
        IMovable im = this;
        Debug.Log(im);
        kh.add(im);
        
    }

    public void id()
    {
        Debug.Log("me me me");
    }
}
