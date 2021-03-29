using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    public float speed = 10f;
    public float jumpspeed = 5f;
    private bool Isgrounded = true;
    Vector2 velocity;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriterenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        var h = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
        if (Input.GetKey(KeyCode.Space) && Isgrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpspeed);
            animator.SetBool("jump", true);
        }
        else
        {
            if(Isgrounded)
                animator.SetBool("jump", false);
        }
        if (h != 0)
        {
            animator.SetBool("walk", true);
            spriterenderer.flipX = h < 0;
        }
        else
            animator.SetBool("walk", false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Vector3 direction = transform.position - collision.gameObject.transform.position;
        Vector2 direction = collision.GetContact(0).normal;
        if (collision.gameObject.tag == "ground" )
        {
            if (direction.x == 1) print("right");
            if (direction.x == -1) print("left");
            if (direction.y == 1)
            {
                print("up");
                Isgrounded = true;
            }
            if (direction.y == -1) print("down");
        }
        if (collision.gameObject.tag == "pipe" )
        {
            if (direction.y == 1 || direction.x == -1 || direction.x == 1)
            {
                print("up");
                Isgrounded = true;
            }
        }
        if (collision.gameObject.tag == "QuestionBlock" )
        {
            if (direction.x == 1) print("right");
            if (direction.x == -1) print("left");
            if (direction.y == 1)
            {
                print("up");
                Isgrounded = true;
            }
            if (direction.y == -1) print("down");
        }
        if (collision.gameObject.tag == "breakable")
        {
            if (direction.x == 1) print("right");
            if (direction.x == -1) print("left");
            if (direction.y == 1)
            {
                print("up");
                Isgrounded = true;
            }
            if (direction.y == -1) Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            if (direction.y == 1)
            {
                print("collision is up enemy");
                Destroy(collision.gameObject);
            }
            else
            {
                print("collision is down");
                SceneManager.LoadScene(0);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "pipe" || collision.gameObject.tag == "QuestionBlock" || collision.gameObject.tag == "breakable"|| collision.gameObject.tag == "fall")
            if (direction.y > 0)
            {
                Isgrounded = false;
            }
            else
            {
                print("edgfhjk");
                Isgrounded = true;
            }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "fall")
        SceneManager.LoadScene(0);
    }
}