using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    public float Speed => _speed;
    private float _speed = 10;
    
    
    public void Move(Vector3 direction){
        
    }

}
