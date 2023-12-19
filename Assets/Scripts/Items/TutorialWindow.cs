using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialWindow : MonoBehaviour, IInteractable
{
    private Player player;
    public GameObject text;

    public void Interact()
    {
        if(player != null){
            Destroy(text.gameObject);
            Destroy(gameObject);
        } 
    }

    void Start(){

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
