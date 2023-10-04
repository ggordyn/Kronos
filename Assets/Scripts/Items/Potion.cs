using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour, IInteractable
{
    private Player player;
    private AudioManager audioManager;
    public GameObject exitStairs;
    public GameObject potionSprite;
    private EnchantedPot enchantedPot;
    public void Interact()
    {
        if(player != null){
            audioManager.Play("Grab");
            potionSprite.SetActive(true);
            exitStairs.SetActive(true);
            enchantedPot.hasPotion = true;
            Destroy(gameObject);
        } 
    }

    void Start(){
        audioManager = FindObjectOfType<AudioManager>();
        enchantedPot = FindObjectOfType<EnchantedPot>();
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
