using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Loading : MonoBehaviour
{
    public GameObject LoadingScreen;
    public Image loadingBar;

    public void LoadScene(string name){
        StartCoroutine(LoadSceneAsync(name));
    }


    IEnumerator LoadSceneAsync(string name){
        AsyncOperation operation = SceneManager.LoadSceneAsync(name);
        LoadingScreen.SetActive(true);
        while(!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);
            loadingBar.fillAmount = progressValue;
            yield return null;
        }
    }
}
