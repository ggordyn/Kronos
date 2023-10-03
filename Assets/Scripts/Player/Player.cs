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
    float turnSmoothVelocity;
    public float interactDistance;
    public LayerMask interactMask;
    private bool footstepsPlaying = false;

    Animator _animator;
    

    // Start is called before the first frame update
    void Start()
    {
        _movementController = GetComponent<PlayerMovementController>();
        _timeShiftController = GetComponent<TimeShiftController>();
        _animator = GetComponentInChildren<Animator>();
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
            _movementController.Jump();
        }

        // Move
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        _animator.SetFloat("speed", direction.magnitude);
        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            _movementController.Move(moveDir.normalized);
            
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
