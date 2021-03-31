using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionblock : MonoBehaviour
{
    public Sprite block;
    private Animator animator;
    private SpriteRenderer spriterenderer;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 direction = collision.GetContact(0).normal;

        if (collision.gameObject.tag == "player")
        {
            if (direction.y == 1)
            {
                ChangeSprite();
            }
        }
    }
            public void ChangeSprite()
    {
        GetComponent<Animator>().enabled = false;
        GetComponent<SpriteRenderer>().sprite = block;
    }
}
