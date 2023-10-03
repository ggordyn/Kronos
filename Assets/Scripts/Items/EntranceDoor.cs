using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceDoor : MonoBehaviour, IInteractable
{
    private Player player;
    private bool hasKey = false;
    public GameObject openDoor;
    public GameObject Room;
    public TimeShiftController timeShiftController;

    void Start(){
        //Unlock();
    }

    void Update(){
        if(player != null && Input.GetButtonDown("Interact")){
           ((IInteractable)this).Interact();
        }
    }
    
    public void Unlock(){
        hasKey = true;
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
            if(hasKey){
                openDoor.SetActive(true);
                Room.SetActive(true);
                timeShiftController.UpdateObjects();
                Destroy(this.gameObject);
            }else{
                Debug.Log("Falta llave");
            }
        } 
    }
}
