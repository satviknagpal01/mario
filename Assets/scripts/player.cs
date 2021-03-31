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
    private PhysicsMaterial2D physics;
    public float friction;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        physics = GetComponent<PhysicsMaterial2D>();
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
            if (Isgrounded)
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
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        // see if the obect is futher left/right or up down
        if (collision.gameObject.tag == "ground")
        {
            if (direction.y > 0)
            {
                Isgrounded = true;
            }
            else
                Isgrounded = false;
        }
        if (collision.gameObject.tag == "pipe")
        {

            Isgrounded = true;
        }
        if (collision.gameObject.tag == "QuestionBlock")
        {
            if (direction.y > 0)
            {
                Isgrounded = true;
            }
            else if (direction.y < 0)
            {
                Isgrounded = false;
            }
        }
        if (collision.gameObject.tag == "breakable")
        {
            Isgrounded = true;
            if (direction.y > 0)
            {
                Isgrounded = true;
                Isgrounded = true;
            }
            else if (direction.y < 0)
            {
                Destroy(collision.gameObject);
                Isgrounded = false;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {   
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0) { SceneManager.LoadScene(0); }
                else { SceneManager.LoadScene(0); }

            }
            else
            {
                if (direction.y > 0) { Destroy(collision.gameObject); }
                else { SceneManager.LoadScene(0); ; }

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "breakable" || collision.gameObject.tag == "QuestionBlock" || collision.gameObject.tag == "pipe")
            Isgrounded = false;
    }
}