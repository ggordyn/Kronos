using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMoveable
{
    public float Speed => _speed;
    private float _speed = 6f;
    private float gravity = -3*9.8f;
    Vector3 velocity;
    private CharacterController characterController;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;
    Animator animator;

    
    public void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
    }

    public void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("isGrounded", isGrounded);
        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }
    }

    public void Move(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime * Speed);

    }

    public void Jump(){
        if(isGrounded){
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }

    public void Fall(){
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

}
