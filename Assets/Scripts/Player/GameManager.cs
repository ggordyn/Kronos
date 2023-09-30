using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int lives = 3;
    public float hurtCooldown = 1f;
    private float hurtTimer = 0f;
    public float fallVelocityLimit = -13.5f;
    public PlayerFlashRed playerFlashRed;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (hurtTimer > 0f){
            if(hurtTimer > hurtCooldown){
                hurtTimer = 0f;
            }else{
                hurtTimer += Time.deltaTime;
            }
        }
    }

    public void PlayerHurt(){
        if(hurtTimer == 0f){
            lives -= 1;
            hurtTimer += Time.deltaTime;
            playerFlashRed.FlashRed(0.1f);
            Debug.Log("Ouch!");
        }
    }
}
