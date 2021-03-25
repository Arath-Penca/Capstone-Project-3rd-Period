
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private bool isAttackingBasic = false;
    private bool isAttackingComplex = false;
    public int health = 6;

    private string roomName;


    private float originalGravity;

    // Start is called before the first frame update
    void Start()
    {
        /* rigidbody2D = GetComponent<Rigidbody2D>();
         xStart = (float)transform.position.x;
         yStart = (float)transform.position.y;*/
        originalGravity = rigidbody.gravityScale;
        Scene scene = SceneManager.GetActiveScene();
        roomName = scene.name;
    }

    // Update is called once per frame
    void Update()
    {
        isAttackingBasic = isPlaying(animator, "isAttackingBasic", 0);

        float nerfMovePower = 0.0f;
        float nerfJumpPower = 0.0f;

        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).ToString());
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0));

        if (isAttackingBasic)
        {
            nerfJumpPower = -9.0f;
        }
        else
        {
            nerfJumpPower = 0.0f;
        }


        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector2(-movePower, rigidbody.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            Debug.Log(nerfJumpPower);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector2(movePower, rigidbody.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

        if (Input.GetKeyDown(KeyCode.W) && animator.GetBool("isJumping") != true)
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

        if (Input.GetKeyDown(KeyCode.S) && animator.GetBool("isJumping") == false)
        {
            animator.SetBool("isAttackingBasic", true);
        }

        if (Input.GetKeyDown(KeyCode.W) && animator.GetBool("isJumping"))
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0f);
            animator.SetBool("isAttackingComplex", true);
            rigidbody.gravityScale = originalGravity + 1;
        }else if(animator.GetBool("isAttackingComplex") == false)
        {
            rigidbody.gravityScale = originalGravity;
        }

        if (animator.GetBool("isAttackingComplex") && !animator.GetBool("isJumping"))
        {
            rigidbody.velocity = new Vector2(Mathf.Lerp(rigidbody.velocity.x, 0, 0.5f), rigidbody.velocity.y);
        }

        if(animator.GetBool("isJumping") && animator.GetBool("isAttackingSmash") == false  && Input.GetKeyDown(KeyCode.S) && animator.GetBool("isAttackingComplex") == false)
        {
            animator.SetBool("isAttackingSmash", true);
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, -20f);
        }

        if(health <= 0)
        {
            SceneManager.LoadScene(roomName);
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

    bool isPlaying(Animator anim, string stateName, int layer)
    {
        if (anim.GetCurrentAnimatorStateInfo(layer).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "SlimeAttack")
        {
            Debug.Log("Getting attacked");
            health--;
        }
    }
}
