using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EntranceKey : MonoBehaviour, IInteractable
{

    private Player player;
    public EntranceDoor entranceDoor;
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

    void IInteractable.Interact()
    {
        if(player != null){
            entranceDoor.Unlock();
            Destroy(gameObject);
        } 
    }
}
