using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questionblock : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {

        animator = GetComponent<Animator>();
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

            if (direction.y == +1)
            {
                animator.SetBool("hit", true);
            }
            else
                animator.SetBool("hit", false);
        }
    }
}
