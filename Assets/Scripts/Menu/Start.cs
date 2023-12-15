using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start: MonoBehaviour
{

	public void StartOption(string name){
		//FindObjectOfType<GameManager>().LoadScene(name);
		FindObjectOfType<Loading>().LoadScene(name);
	}
}

