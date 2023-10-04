using System;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Transform target; // Set this to your camera or the target transform you want the plane to face.

    void Update()
    {
        if (target != null)
        {
            Vector3 directionToTarget = target.position - transform.position;
            directionToTarget.y = 0; // Optional: If you want to keep the plane's up direction vertical.

            if (directionToTarget != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = lookRotation;
            }
        }
    }
}
