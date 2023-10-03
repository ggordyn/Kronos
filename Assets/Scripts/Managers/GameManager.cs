using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int initialLives = 3;
    public int lives;
    public float hurtCooldown = 1f;
    private float hurtTimer = 0f;
    public float fallVelocityLimit = -13.5f;
    public PlayerFlashRed playerFlashRed;
    private AudioManager audioManager;
    private HealthUI healthUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        lives = initialLives;
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.Play("Menu");
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
            if(playerFlashRed == null)
                playerFlashRed = FindObjectOfType<PlayerFlashRed>();
            lives -= 1;
            hurtTimer += Time.deltaTime;
            playerFlashRed.FlashRed(0.1f);
            audioManager.Play("Hurt");
            if(healthUI == null)
                healthUI = FindObjectOfType<HealthUI>();
            healthUI.updateHearts(lives);
            if(lives == 0){
                LoadScene("Menu");
                lives = initialLives;
            }
        }
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
        healthUI = FindObjectOfType<HealthUI>();
        switch(sceneName){
            case "Menu":
                audioManager.StopAll();
                audioManager.Play("Menu");
                break;
            case "Level1":
                audioManager.StopAll();
                audioManager.Play("Theme");
                break;
        }
    }
}
