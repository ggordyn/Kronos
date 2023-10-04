using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private PlayerMovementController _movementController;
    private TimeShiftController _timeShiftController;
    private AudioManager audioManager;
    
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;
    public float interactDistance;
    public LayerMask interactMask;
    private bool footstepsPlaying = false;
    private CmdMovement cmdMovement;
    private CmdJump cmdJump;
    Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        _movementController = GetComponent<PlayerMovementController>();
        _timeShiftController = GetComponent<TimeShiftController>();
        _animator = GetComponentInChildren<Animator>();
        cmdJump = new CmdJump(_movementController);
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Movement Keys
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


        //Time Shift
        if(Input.GetButtonDown("TimeShift")){
            _timeShiftController.TimeShift();
        }

        //Jump
        if(Input.GetButtonDown("Jump")){
            cmdJump.Execute();
        }

        // Move
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        _animator.SetFloat("speed", direction.magnitude);
        if(direction.magnitude >= 0.1f){
            cmdMovement = new CmdMovement(direction, this, _movementController);
            cmdMovement.Execute();
            
            if(!footstepsPlaying && _movementController.isGrounded)
                StartCoroutine(FootstepsCoroutine(0.35f));
        }

        //Gravity
        _movementController.Fall();
    }

    private IEnumerator FootstepsCoroutine(float duration){
        footstepsPlaying = true;
        audioManager.Play("Footstep");
        yield return new WaitForSeconds(duration);
        footstepsPlaying = false;
    }
    
}
