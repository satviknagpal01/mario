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
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(h * speed, rigidbody2D.velocity.y);
        if(h!=0)
        {
            spriterenderer.flipX = h<0;
        }
        if (Input.GetKey(KeyCode.Space) && Isgrounded)
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpspeed);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            Isgrounded = true;

        if (collision.gameObject.tag == "ground")
            Debug.Log("Collision with plant");
        if (collision.gameObject.tag == "Enemy")
            SceneManager.LoadScene(1);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            Isgrounded = false;
    }
}   
