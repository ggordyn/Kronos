using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnchantedPot : MonoBehaviour, IInteractable
{
    public bool hasPotion = false;

    public GameObject potionSprite;
    private Player player;
    public GameObject potionBubble;
    private GameManager gameManager;

    void Start(){
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update(){
        if(player != null && Input.GetButtonDown("Interact")){
           ((IInteractable)this).Interact();
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
            potionBubble.SetActive(true);
            player = other.gameObject.GetComponent<Player>();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player"){
            player = null;
            potionBubble.SetActive(false);
        }
    }

    void IInteractable.Interact()
    {
        if(player != null && hasPotion){
            potionBubble.SetActive(false);
            potionSprite.SetActive(false);
            gameManager.LoadScene("Victory");
        } 
    }
}
