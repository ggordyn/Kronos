using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FlyingSword : MonoBehaviour
{
     [SerializeField]
    public GameObject Pos1;
    [SerializeField]
    public GameObject Pos2;
    [SerializeField]
    public float speed = 1f;
    public float pushSpeed = 10f;
    public bool canMove;
    public bool firstMove;
    private Vector3 targetPos1;
    private Vector3 targetPos2;
    public float rotationSpeed = 6f;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        firstMove = true;
        targetPos1 = Pos1.transform.position;
        targetPos2 = Pos2.transform.position;
       
    }

    void OnTriggerEnter(Collider c){
        if(c.tag == "Player"){
            gameManager.PlayerHurt();
            PlayerMovementController pm = c.gameObject.GetComponent<PlayerMovementController>();
            Vector3 pushDirection = (c.transform.position - transform.position).normalized;
            pm.Push(pushSpeed, pushDirection);
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        if(transform.position == targetPos1)
        {
            firstMove = false;
        }
        if (transform.position == targetPos2)
        {
            firstMove = true;
        }
        if (canMove)
        {
            if (firstMove)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos1, speed* Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos2, speed* Time.deltaTime);
            }
        }
       
    }
}
