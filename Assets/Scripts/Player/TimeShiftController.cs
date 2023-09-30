using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeShiftController : MonoBehaviour
{
    public float timeShiftLimit;
    private float timeShiftTimer = 0f;
    public float timeShiftCooldown = 20f;
    private float timeShiftCooldownTimer = 0f;
    private GameObject[] presentObjects;
    private GameObject[] pastObjects;

    private ChromaticAberration chromaticAberration;
    private Grain grain;

    // Start is called before the first frame update
    void Start()
    {
        
        Camera.main.GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings<ChromaticAberration>(out chromaticAberration);
        Camera.main.GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings<Grain>(out grain);
        presentObjects = GameObject.FindGameObjectsWithTag("Present");
        pastObjects = GameObject.FindGameObjectsWithTag("Past");
        foreach(GameObject o in pastObjects){
                o.SetActive(false);
            }
    }

    public void UpdateObjects(){
        presentObjects = GameObject.FindGameObjectsWithTag("Present");
        pastObjects = GameObject.FindGameObjectsWithTag("Past");
        foreach(GameObject o in pastObjects){
                o.SetActive(false);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeShiftTimer > 0f){
            if(timeShiftTimer <= timeShiftLimit){
                timeShiftTimer += Time.deltaTime;
            }else{
                timeShiftTimer = 0f;
                chromaticAberration.active = false;
                grain.active = false;
                foreach(GameObject o in presentObjects){
                    if(o != null)
                        o.SetActive(true);
                }
                foreach(GameObject o in pastObjects){
                    if(o != null)
                        o.SetActive(false);
                }
                timeShiftCooldownTimer += Time.deltaTime;
            }
        }

        if(timeShiftCooldownTimer > 0f){
            if(timeShiftCooldownTimer <= timeShiftCooldown){
                timeShiftCooldownTimer += Time.deltaTime;
            }else{
                timeShiftCooldownTimer = 0f;
            }
        }
    }

    public void TimeShift(){
        if(timeShiftCooldownTimer == 0f && timeShiftTimer == 0f){
            
            chromaticAberration.active = true;
            grain.active = true;
            foreach(GameObject o in presentObjects){
                if(o != null)
                    o.SetActive(false);
            }
            foreach(GameObject o in pastObjects){
                if(o != null)
                    o.SetActive(true);
            }
            timeShiftTimer = Time.deltaTime;
        }
        
    }
}
