using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerActor))]
public class GameManager : MonoBehaviour
{

    public int initialLives => GetComponent<PlayerActor>().Stats.InitialLives;
    public int lives;
    public float hurtCooldown => GetComponent<PlayerActor>().Stats.HurtCooldown;
    private float hurtTimer = 0f;
    public float fallVelocityLimit => GetComponent<PlayerActor>().Stats.FallVelocityLimit;
    public PlayerFlashRed playerFlashRed;
    private AudioManager audioManager;
    private HealthUI healthUI;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        lives = initialLives;
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.OnPlay += OnPlay;
        
        audioManager.OnPlay?.Invoke("Menu");
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
            if(playerFlashRed == null){
                playerFlashRed = FindObjectOfType<PlayerFlashRed>();
                playerFlashRed.OnFlashRed += FlashRed;
            }
            
            lives -= 1;
            hurtTimer += Time.deltaTime;
            
            playerFlashRed.OnFlashRed?.Invoke(0.1f);
            audioManager.OnPlay?.Invoke("Hurt");
            if(healthUI == null){
                healthUI = FindObjectOfType<HealthUI>();
                healthUI.OnUpdateHearts += UpdateHearts;
            }
            healthUI.OnUpdateHearts?.Invoke(lives);
            if(lives == 0){
                LoadScene("GameOver");
                lives = initialLives;
            }
        }
    }

    public void LoadScene(string sceneName){
        SceneManager.LoadScene(sceneName);
        switch(sceneName){
            case "Menu":
                audioManager.StopAll();
                audioManager.OnPlay?.Invoke("Menu");
                lives = initialLives;
                break;
            case "Level1":
                audioManager.StopAll();
                audioManager.OnPlay?.Invoke("Theme");
                break;
            case "Victory":
                audioManager.StopAll();
                audioManager.OnPlay?.Invoke("Victory");
                break;
            case "GameOver":
                audioManager.StopAll();
                audioManager.OnPlay?.Invoke("GameOver");
                break;
        }
    }

    private void UpdateHearts(int lives)
    {
        if (healthUI != null)
        {
            healthUI.updateHearts(lives);
        }
    }

    private void FlashRed(float duration){
        playerFlashRed.FlashRed(duration);
    }

    private void OnPlay(string name){
        audioManager.Play(name);
    }
}
