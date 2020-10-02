using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGoku : MonoBehaviour
{
    private bool volar = false;
    

    private const int ANIM_CORRER= 0;
    private const int ANIM_VOLAR= 1;

    private Rigidbody2D rb; //Pisicion
    private Animator animator; //Movimiento
    private SpriteRenderer sr;
    private BoxCollider2D bx;
    private Transform _transform;

    private float JumpForce = 10;

    void Start()
    {
        //Aumentar disminuir la velocidad del objeto
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        _transform = GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, rb.velocity.y);

        if (Input.GetKey(KeyCode.UpArrow)||Input.GetKey(KeyCode.DownArrow)&& volar)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(5, rb.velocity.y);
            sr.flipX = false;

        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(-5, rb.velocity.y);
            sr.flipX = true;

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && rb.gravityScale == 5 )
        {
            rb.AddForce(new Vector2(rb.velocity.x, JumpForce), ForceMode2D.Impulse);
        }
        if (volar)
        {
            animator.SetInteger("Estado",ANIM_VOLAR);
            rb.gravityScale = 0;
        }
        if (Input.GetKey("x"))
        {
            animator.SetInteger("Estado", ANIM_CORRER);
            rb.gravityScale = 5;
            volar = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) && volar)
        {
            rb.velocity = new Vector2(rb.velocity.x, +3);
        }
        if (Input.GetKey(KeyCode.DownArrow) && volar)
        {
            rb.velocity = new Vector2(rb.velocity.x, -3);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Arbol")
        {
            volar = true;
        }
    }
}
