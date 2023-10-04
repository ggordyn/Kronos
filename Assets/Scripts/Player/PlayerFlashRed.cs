using System;
using System.Collections;
using UnityEngine;

public class PlayerFlashRed : MonoBehaviour
{
    public Renderer[] playerRenderers; 
    public Material redMaterial; 
    public Material normalMaterial; 

    private Coroutine flashCoroutine;
    public Action<float> OnFlashRed;

    void Start(){
        playerRenderers = GetComponentsInChildren<Renderer>();
    }
    // Call this method to initiate the red flash.
    public void FlashRed(float duration)
    {
        if (flashCoroutine != null)
        {
            StopCoroutine(flashCoroutine);
        }

        flashCoroutine = StartCoroutine(FlashRedCoroutine(duration));
    }

    private IEnumerator FlashRedCoroutine(float duration)
    {
        foreach(Renderer r in playerRenderers){
            r.material = redMaterial;
        }
        yield return new WaitForSeconds(duration);

        if (normalMaterial != null)
        {
            foreach(Renderer r in playerRenderers){
                r.material = normalMaterial;
            }
        }
    }
}

