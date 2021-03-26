using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttackScript : MonoBehaviour
{

    public float damage = 4.0f;
    public Transform player;
    public Vector2 relativePoint;
    public Rigidbody2D rigidbody2D;
    public Animator animator;

    public float distanceSeek = 7.0f;
    public float speed = 0.01f;

    public int health = 100;
    public float originalScale = 0;

    public float attackDis = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        originalScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

        if(health <= 0)
        {
            if(gameObject.tag == "Boss")
            {
                // transfer to the congratutatlinnons slkdfjslkd room;
            }
            else
            {Destroy(gameObject);

            }
            
        }
        float distance_from_player = Vector2.Distance(player.position, transform.position);
        //Debug.Log(distance_from_player);

        if (distance_from_player < distanceSeek && distance_from_player > attackDis)
        {
            Vector2 newDis = Vector2.MoveTowards(transform.position, player.position, speed);
            transform.position = new Vector2(newDis.x, transform.position.y);
            //rigidbody2D.pos
            //Debug.Log("Moving towards");
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isPacing", true);
        }else if(distance_from_player < attackDis)
        {
            //Vector2 newDis = Vector2.MoveTowards(transform.position, player.position, 0.001f);
            //transform.position = new Vector2(newDis.x, transform.position.y);
            animator.SetBool("isIdle", false);
            animator.SetBool("isAttacking", true);
            animator.SetBool("isPacing", false);
        }
        else 
        {
            animator.SetBool("isIdle", true);
            animator.SetBool("isAttacking", false);
            animator.SetBool("isPacing", false);
        }
        //Debug.Log(Vector2.Angle(player.position, transform.position));
        Vector3 enemyDirectionLocal = transform.InverseTransformPoint(player.transform.position);

        if (transform.position.x > player.transform.position.x)
        {
            transform.localScale = new Vector2(originalScale, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(-originalScale, transform.localScale.y);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 enemyDirectionLocal = transform.InverseTransformPoint(player.transform.position);

        int dir = 0;
        if (transform.position.x > player.transform.position.x)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }

        if (collision.tag == "BasicBlade")
        {
            Debug.Log("Got Hib by basic");
            health -= 15;
            rigidbody2D.velocity = new Vector2(dir * 20, rigidbody2D.velocity.y);
        }

        if (collision.tag == "ComplexBlade")
        {
            Debug.Log("Got Hib by Complex");
            health -= 50;
            rigidbody2D.velocity = new Vector2(dir * 25, rigidbody2D.velocity.y);
        }

        if (collision.tag == "SmashBlade")
        {
            health -= 60;
            Debug.Log("Got Hib by Smash");
            rigidbody2D.velocity = new Vector2(dir * 15, rigidbody2D.velocity.y);
        }
    }
}
