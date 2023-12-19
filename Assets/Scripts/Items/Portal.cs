using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"){
           FindObjectOfType<GameManager>().LoadScene("Level1");
           FindObjectOfType<GameManager>().tutorial = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
