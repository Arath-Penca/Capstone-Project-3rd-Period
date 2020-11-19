using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraObject;
    public float cameraYOffset = 0.0f;
    public float cameraSmoothness = 0.3f;
    public int cameraRefreshRate = 60;
    public int cameraWidth = 400;
    public int cameraHeight = 400;
    public bool isFullscreen = false;


    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(cameraWidth, cameraHeight, isFullscreen, cameraRefreshRate);
        cameraYOffset = transform.position.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newPosition = new Vector3(cameraObject.position.x, cameraObject.position.y, cameraYOffset);
        transform.position = Vector3.Slerp(cameraObject.transform.position, newPosition, cameraSmoothness);
    }
}
