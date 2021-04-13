using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private AudioSource audioSource;
    public AudioClip[] clips = new AudioClip[5];
    public int coin=0;
    public int score= 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        
    }
    // Update is called once per frame
    void Update()
    {
        scoreupdate.score = score;
        coinupdate.coin = coin;
        var h = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
        if (Input.GetKey(KeyCode.Space) && Isgrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpspeed);
            animator.SetBool("jump", true);
            audioSource.clip = clips[2];
            audioSource.Play();
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
        if (Isgrounded == false && Input.GetKey(KeyCode.Space))
            speed = 4;
        else
            speed = 6;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;

        if (collision.gameObject.tag == "QuestionBlock")
        {

            if (direction.y == -1)
            {
                coin++;
                score += 100;
                collision.gameObject.tag = "done";
                print(coin);
                print(score);
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;
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
        if (collision.gameObject.tag == "QuestionBlock"|| collision.gameObject.tag == "done")
        {
            if (direction.y > 0)
            {
                Isgrounded = true;
            }
            else if (direction.y == 0)
            {
                Isgrounded = false;
            }
        }
        if (collision.gameObject.tag == "plant")
        {
            SceneManager.LoadScene(2);
        }
            if (collision.gameObject.tag == "breakable")
        {
            if (direction.y > 0)
            {
                Isgrounded = true;
            }
            else if (direction.y < 0)
            {
                Destroy(collision.gameObject);
                audioSource.clip = clips[0];
                audioSource.Play();
                Isgrounded = false;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {   
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                {
                    SceneManager.LoadScene(2);
                    
                }
                else {
                    SceneManager.LoadScene(2);
                }

            }
            else
            {
                if (direction.y > 0) { Destroy(collision.gameObject);
                    audioSource.clip = clips[1];
                    audioSource.Play();
                    score += 100;
                }
                else
                {
                    SceneManager.LoadScene(2);
                }

            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "breakable" || collision.gameObject.tag == "QuestionBlock" || collision.gameObject.tag == "pipe"|| collision.gameObject.tag == "done")
            Isgrounded = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {   if(collider.gameObject.tag =="fall")
        SceneManager.LoadScene(2);
        if (collider.gameObject.tag == "coin")
        {
            coin++;
            score += 100;
            Destroy(collider.gameObject);
            print(coin);
        }
        if (collider.gameObject.tag == "win")
        {
            SceneManager.LoadScene(3);
        }
    }
}