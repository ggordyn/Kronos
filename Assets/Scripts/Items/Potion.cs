using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IInteractable
{
    private Player player;
    private AudioManager audioManager;
    public GameObject exitStairs;
    public void Interact()
    {
        if(player != null){
            audioManager.Play("Grab");
            exitStairs.SetActive(true);
            Destroy(gameObject);
        } 
    }

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

    
}
