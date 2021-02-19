using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleFire : MonoBehaviour
{
    
    public Transform barrelTip;
    
    public GameObject bullet;

    private Vector2 lookDirection;
    private float lookAngle;

    float from = 10f;
    float to = 0f;
    float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle - 90f);

        if (Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTip.position, barrelTip.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTip.up * 10f;
    }

    

}
