//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private float horiz_input;

    private float jumpCounter;
    public float jumpTime;
    private bool isJumping;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horiz_input = Input.GetAxis("Horizontal");

        //control speed of player
        body.velocity = new Vector2(horiz_input * speed, body.velocity.y);

        //flip player when moving left or right
        if (horiz_input > 0.01f)
            transform.localScale = new Vector3(8, 8, 8);
        else if (horiz_input < -0.01f)
            transform.localScale = new Vector3(-8, 8, 8);

        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded())
        {
            isJumping = true;
            jumpCounter = jumpTime;
            Jump();
        }

        //controls jump height
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && isJumping)
        {
            if (jumpCounter > 0)
            {
                Jump();
                jumpCounter -= Time.deltaTime;
            }
            else isJumping = false;
        }

        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W)))
            isJumping = false;

        //set animation
            anim.SetBool("run", horiz_input != 0);
        anim.SetBool("grounded", isGrounded());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        //grounded = false;
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
                                                    boxCollider.bounds.size, 0,
                                                    Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center,
                                                    boxCollider.bounds.size, 0,
                                                    new Vector2(transform.localScale.x, 0),
                                                    0.1f, wallLayer);
        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horiz_input == 0 /*&& isGrounded()*/ && !onWall();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlueTag")
        {
            GameManager.gm.UpdateGemScore(0);
            GameManager.gm.GemCollectSound.Play();
            Destroy(collision.gameObject, 0);

        }
        if (collision.gameObject.tag == "GreenTag")
        {
            GameManager.gm.UpdateGemScore(1);
            GameManager.gm.GemCollectSound.Play();
            Destroy(collision.gameObject, 0);

        }
        if (collision.gameObject.tag == "RedTag")
        {
            GameManager.gm.UpdateGemScore(2);
            GameManager.gm.GemCollectSound.Play();
            Destroy(collision.gameObject, 0);

        }
    }
}
