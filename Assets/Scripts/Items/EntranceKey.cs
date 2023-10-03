using UnityEngine.UI;
using UnityEngine;

public class EntranceKey : MonoBehaviour, IInteractable
{
    public GameObject keySprite;
    private Player player;
    private AudioManager audioManager;
    public EntranceDoor entranceDoor;
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

    void IInteractable.Interact()
    {
        if(player != null){
            audioManager.Play("Grab");
            entranceDoor.Unlock();
            keySprite.SetActive(true);
            Destroy(gameObject);
        } 
    }
}
