using UnityEngine;
using UnityEngine.UI;

public class EntranceDoor : MonoBehaviour, IInteractable
{
    private Player player;
    private bool hasKey = false;
    public GameObject openDoor;
    public GameObject Room;
    public TimeShiftController timeShiftController;
    public GameObject keySprite;
    private AudioManager audioManager;
    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
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
                keySprite.SetActive(false);
                audioManager.Play("Door");
                Destroy(this.gameObject);
            }else{
                Debug.Log("Falta llave");
            }
        } 
    }
}
