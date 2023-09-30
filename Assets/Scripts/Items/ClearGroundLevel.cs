using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearGroundLevel : MonoBehaviour
{
    public GameObject openDoor;
    public GameObject groundFloor;
    public GameObject secondFloor;

    void OnTriggerEnter(Collider o){
        if(o.tag == "Player")
            openDoor.transform.rotation = Quaternion.Euler(0, 0, 0);
            groundFloor.SetActive(false);
            secondFloor.SetActive(false);
            Destroy(this.gameObject);
    }

}
