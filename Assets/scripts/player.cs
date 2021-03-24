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
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "pipe" || collision.gameObject.tag == "QuestionBlock")
        {
            if (direction.y > 0)
            {
                print("collision is up");
                Isgrounded = true;
            }
            else
            {
                print("collision is down");
                Isgrounded = false;
            }
            if (collision.gameObject.tag == "Enemy")
                if (direction.y > 0) { print("collision is up"); }
                else
                {
                    print("collision is down");
                }
            //SceneManager.LoadScene(0);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Vector3 direction = transform.position - collision.gameObject.transform.position;
        if (collision.gameObject.tag == "ground"|| collision.gameObject.tag == "pipe" || collision.gameObject.tag == "QuestionBlock")
            if (direction.y > 0)
            {
                print("collision is up");
                Isgrounded = false;
            }
            else
            {
                print("collision is down");
                Isgrounded = true;
            }
    }
}
/* 
 * 
 * Vector3 direction = transform.position - c.gameObject.transform.position;
         // see if the obect is futher left/right or up down
         if (Mathf.Abs (direction.x) > Mathf.Abs (direction.y)) {
 
             if(direction.x>0){print("collision is to the right");}
             else{print("collision is to the left");}
         
         }else{
 
             if(direction.y>0){print("collision is up");}
             else{print("collision is down");}
 
         }
 
 
     
     }
 */