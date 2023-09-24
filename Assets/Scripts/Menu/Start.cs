using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start: MonoBehaviour
{

	public void StartOption(String name){
		SceneManager.LoadScene(name);
	}
}

