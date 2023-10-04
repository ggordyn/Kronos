using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

[RequireComponent(typeof(TimeShift))]
public class TimeShiftController : MonoBehaviour
{
    public float timeShiftLimit => GetComponent<TimeShift>().Stats.TimeShiftLimit;
    private float timeShiftTimer = 0f;
    public float timeShiftCooldown => GetComponent<TimeShift>().Stats.TimeShiftCooldown;
    private float timeShiftCooldownTimer = 0f;
    public Slider timeShiftUI;
    public Slider timeShiftCooldownUI;
    public GameObject timeShiftCooldownObject;
    private GameObject[] presentObjects;
    private GameObject[] pastObjects;

    private AudioManager audioManager;
    private ChromaticAberration chromaticAberration;
    private Grain grain;

    // Start is called before the first frame update
    void Start()
    {
        
        Camera.main.GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings<ChromaticAberration>(out chromaticAberration);
        Camera.main.GetComponent<PostProcessVolume>().sharedProfile.TryGetSettings<Grain>(out grain);
        audioManager = FindObjectOfType<AudioManager>();
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
        UpdateTimeShiftUI();
        if(timeShiftTimer > 0f){
            if(timeShiftTimer <= timeShiftLimit){
                timeShiftTimer += Time.deltaTime;
            }else{
                timeShiftTimer = 0f;
                audioManager.ChangePitch("Theme", 1f);
                audioManager.Stop("Clock");
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
            timeShiftCooldownObject.SetActive(true);
            if(timeShiftCooldownTimer <= timeShiftCooldown){
                timeShiftCooldownTimer += Time.deltaTime;
            }else{
                timeShiftCooldownObject.SetActive(false);
                timeShiftCooldownTimer = 0f;
            }
        }
    }

    public void TimeShift(){
        if(timeShiftCooldownTimer == 0f && timeShiftTimer == 0f){
            
            chromaticAberration.active = true;
            grain.active = true;
            audioManager.ChangePitch("Theme", -0.5f);
            audioManager.Play("Clock");
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

    private void UpdateTimeShiftUI(){
        if(timeShiftTimer > 0){
            timeShiftUI.value = timeShiftLimit - timeShiftTimer;
        }else{
            if(timeShiftCooldownTimer > 0){
                timeShiftCooldownUI.value = timeShiftCooldownTimer;
            }else{
                timeShiftUI.value = timeShiftLimit;
            }
        }
    }
}
