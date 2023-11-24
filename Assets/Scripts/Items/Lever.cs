using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lever : MonoBehaviour, IInteractable
{
    private Player player;
    public GameObject lever;
    public GameObject leverDown;
    private bool switched = false;
    private AudioManager audioManager;
    public FinalDoor door;
    

    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
    }

    void Update(){
        if(player != null && Input.GetButtonDown("Interact")){
           ((IInteractable)this).Interact();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            player = other.gameObject.GetComponent<Player>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            player = null;
        }
    }

    public void Interact()
    {
        if(player != null && !switched){
            door.TryOpen();
            audioManager.Play("Grab");
            lever.SetActive(false);
            leverDown.SetActive(true);
            switched = true;
        } 
    }

}
