
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    /*public int jumpSpd;
    public int movementSpd;
    public Vector2 originalVector2;
    private Rigidbody2D rigidbody2D;
    public float xStart;
    public float yStart;*/

    public Rigidbody2D rigidbody;
    public Transform transform;
    public Animator animator;
    public BoxCollider2D ground;
    public float movePower = 10f;
    public float jumpPower = 10f;

    private bool isJumping = false;
    private bool isRunning = false;
    private bool airAttackMode = false;

    // Start is called before the first frame update
    void Start()
    {
       /* rigidbody2D = GetComponent<Rigidbody2D>();
        xStart = (float)transform.position.x;
        yStart = (float)transform.position.y;*/
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-movePower, rigidbody.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(movePower, rigidbody.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.Space) && animator.GetBool("isJumping") != true)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpPower);
        }

        if (Mathf.Abs(rigidbody.velocity.x) >= 0.05f)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x, 5.0f);
            animator.SetBool("isAttackingBasic", true);
            //animator.SetBool("isAttackingBasic", false);
            Debug.Log("something something pres s");
        }
        else if(animator.GetBool("isAttackingBasic") == true)
        {
            animator.SetBool("isAttackingBasic", false);
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            airAttackMode = true;
            //rigidbody.velocity = new Vector2(rigidbody.velocity.x, 5.0f);
            animator.SetBool("isAttackingComplex", true);

        }else if(animator.GetBool("isAttackingComplex") == true)
        {
            animator.SetBool("isAttackingComplex", false);
        }

        
        //Debug.Log(animator.GetBool("isAttackingComplex"));
        



        //Debug.Log(rigidbody.velocity.x);

/*        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpd;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2D.velocity.y) < 0.001f)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpd), ForceMode2D.Impulse);
        }

        // Restart to startin position
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector2(xStart, yStart);
        }*/
    }
}
