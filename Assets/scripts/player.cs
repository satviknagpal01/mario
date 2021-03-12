using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 5f;
    public float jumpspeed = 5f;
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
        if(h<0)
        {
            spriterenderer.flipX = h<0;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpspeed);
        }
    }
}
