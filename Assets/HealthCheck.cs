using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private PlayerMovement playerScript;
    public Sprite[] images;

    public Image currentImage;
    void Start()
    {
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {


        int health = playerScript.health;


        if(health <= 0)
        {
            health = 0;
        }else if(health >= 6)
        {
            health = 6;
        }
        currentImage.sprite = images[health];

        
        /*switch (health)
        {
            case 6:
                currentImage = images[6];
                break;

            case 5:

                break;

            case 4:

                break;

            case 3:

                break;

            case 2:

                break;

            case 1:

                break;

            case 0:

                break;
        }
    }*/
    }
}
