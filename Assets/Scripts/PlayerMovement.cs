
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public int jumpSpd;
    public int movementSpd;
    public Vector2 originalVector2;
    private Rigidbody2D rigidbody2D;
    public float xStart;
    public float yStart;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        xStart = (float)transform.position.x;
        yStart = (float)transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * movementSpd;

        if(Input.GetButtonDown("Jump") && Mathf.Abs(rigidbody2D.velocity.y) < 0.001f)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpSpd), ForceMode2D.Impulse);
        }

        // Restart to startin position
        if(Input.GetKey(KeyCode.R))
        {
            transform.position = new Vector2(xStart, yStart);
        }
    }
}
