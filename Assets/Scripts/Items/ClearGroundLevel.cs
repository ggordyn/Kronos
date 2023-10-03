using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGroundLevel : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject groundFloor;
    public GameObject secondFloor;
    private AudioManager audioManager;

    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter(Collider o){
        if(o.tag == "Player")
            openDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
            audioManager.Play("Door_Close");
            groundFloor.SetActive(false);
            secondFloor.SetActive(false);
            Destroy(this.gameObject);
    }

}
