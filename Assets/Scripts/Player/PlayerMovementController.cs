using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMoveable
{
    public float Speed => _speed;
    private float _speed = 6f;
    private float gravity = -3*9.8f;
    public Vector3 velocity;
    private CharacterController characterController;

    public Transform groundCheck;
    public float groundDistance = 1f;
    public GameManager gameManager;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 3f;

    Animator animator;

    
    public void Start(){
        characterController = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        gameManager = FindAnyObjectByType<GameManager>();
    }

    public void Update(){
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        animator.SetBool("isGrounded", isGrounded);
        if(isGrounded && velocity.y < 0){
            if(velocity.y < gameManager.fallVelocityLimit){
                gameManager.PlayerHurt();
            }
            velocity.y = -2f;
        }
    }

    public void Move(Vector3 direction)
    {
        characterController.Move(direction * Time.deltaTime * Speed);

    }

    public void Push(float pushSpeed, Vector3 direction){
        characterController.Move(direction * pushSpeed);
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
