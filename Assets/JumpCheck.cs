using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCheck : MonoBehaviour
{

    public Animator characterAnimator;
    private bool isJumping = false;

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
        if(collision.tag == "Ground")
        {
            isJumping = false;
            characterAnimator.SetBool("isJumping", false);
            Debug.Log("doing stuff;");
            Debug.Log("grounded");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            isJumping = true;
            characterAnimator.SetBool("isJumping", true);
            Debug.Log("doing stuff;");
            Debug.Log("Jumping");
        }
    }


}
