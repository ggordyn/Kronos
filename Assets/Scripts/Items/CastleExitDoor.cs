using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleExitDoor : MonoBehaviour, IInteractable
{
    GameManager gm;
    private Player player;
    public void Interact()
    {
        if(player != null)
            gm.LoadScene("Level2");
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
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
