using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    public void BackToMenu()
    {
        gameManager.LoadScene("Menu");
    }

    public void Exit(){
        Application.Quit();
    }
}
