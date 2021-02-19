using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    public GameObject bullet;

    public int score;

    //public int[] targets = new int[5];

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Target" || collision.gameObject.tag == "Projectile")
        {
            Destroy(bullet);
        }
        /*else if (collision.gameObject.tag == "Enemey")
        {
            score += 50;
        }*/
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
