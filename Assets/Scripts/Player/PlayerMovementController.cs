using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour, IMoveable
{
    public float Speed => _speed;
    private float _speed = 6f;

    float turnSmoothVelocity;
    
    public void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * Speed;
    }

}
