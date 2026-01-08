using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cameraTransform;
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float jumpForce = 5f;
   
    public float acceleration = 5f;  
    private float checker;
    private Vector3 playerVelocity;
    private bool isGrounded;
  
    private Animator animator; 
    private float currentSpeed = 0f;
  
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip jumpSound;
    private float nextTimeToJump = 0f;
    public float jumpRate = 1.5f;
  
    [SerializeField] private AudioSource audioSource;
    void Start()
    { Debug.Log("Start called. Cursor should now be hidden.");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        Debug.Log($"Cursor.visible = {Cursor.visible}, Cursor.lockState = {Cursor.lockState}");
       
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
      
    }



    void Update()
    {
       
    
        RotateTowardsCamera();


        HandleMovement();

    
        Jump();

        ApplyGravity();
    }

    
    void RotateTowardsCamera()
    {
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;  
        Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    
   

    
    void HandleMovement()
    {
        
        
        float moveX = Input.GetAxis("Horizontal"); 
        float moveZ = Input.GetAxis("Vertical");   

       
        Vector3 moveDirection = cameraTransform.forward * moveZ + cameraTransform.right * moveX;
        moveDirection.y = 0f;
        float targetSpeed;
        
        if (Input.GetKey(KeyCode.LeftShift)&& Input.GetKey(KeyCode.W))
        {
            targetSpeed = runSpeed;
        }
        else
        {
            targetSpeed = walkSpeed;
        }
       

        
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        
        controller.Move(moveDirection.normalized * currentSpeed * Time.deltaTime);

        
        Vector3 localMove = transform.InverseTransformDirection(moveDirection.normalized);
        float horizontal = localMove.x; 
        float vertical = localMove.z;   

        
       
            animator.SetFloat("Speed", moveDirection.magnitude * currentSpeed / runSpeed); 
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);
     

        
        checker = moveDirection.magnitude;
    }

    
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Time.time >= nextTimeToJump )
        { 
            playerVelocity.y = jumpForce;
            animator.SetTrigger("Jump");
           playSoundJump();
           nextTimeToJump = Time.time + jumpRate;
              
        }
        

            
   
    }

    
    void ApplyGravity()
    {
        if (!isGrounded)
        {
            playerVelocity.y -= 9.81f * Time.deltaTime;  
        }

       
        controller.Move(playerVelocity * Time.deltaTime);
    }

  public  void OpenDoors()
    {
        animator.SetTrigger("OpenDoor");
    }

    public void Fire()
    {
        animator.SetTrigger("Shoot");
    }

    public void playSoundStep()
    {
        audioSource.PlayOneShot(runSound, 0.2f); 
    }
    public void playSoundJump()
    {
        audioSource.PlayOneShot(jumpSound, 1f); 
    }
}

