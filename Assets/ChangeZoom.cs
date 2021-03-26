using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class ChangeZoom : MonoBehaviour
{

    public CinemachineVirtualCamera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camera.m_Lens.OrthographicSize = 9f;
            Destroy(gameObject);
        }
    }
}
