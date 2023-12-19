using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{

    private int levers = 0;
    public GameObject bubble;
    public void TryOpen(){
        levers++;
        if(levers == 3){
            Quaternion currentRotation = transform.rotation;
            Quaternion newRotation = currentRotation * Quaternion.Euler(0f, -90f, 0f);
            transform.rotation = newRotation;
            Destroy(bubble);
        }
    }
}
