using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Action<int> OnUpdateHearts;
    public void Awake(){
        int lives = FindObjectOfType<GameManager>().lives;
        updateHearts(lives);

    }


    public void updateHearts(int lives){
        for(int i=0; i < hearts.Length; i++){
            if(i < lives){
                hearts[i].sprite =fullHeart;
            }else{
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    
}
