using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject cameraLook;
    private float distance;
    void Start()
    {
        distance = Vector3.Distance(cameraLook.transform.position, transform.position);
    }

    
    void LateUpdate()
    {
        Vector3 resultPosition = cameraLook.transform.position - Vector3.forward * distance;
        transform.position = Vector3.Lerp(transform.position, resultPosition, Time.deltaTime);
        
    }
}
