using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BOSS : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    public Transform leftPoint, rightPoint;
    private int health = 10;

    private float leftx, rightx;
    private bool FaceRight = true;
    public float Speed;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        transform.DetachChildren();
        leftx = leftPoint.position.x;
        rightx = rightPoint.position.x;
        Destroy(leftPoint.gameObject);
        Destroy(rightPoint.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        if (FaceRight)
        {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FaceRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FaceRight = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (health > 0)
            {
                health--;
                anim.SetBool("Hit", true);
                Invoke("setHitFalse", 1.0f);

            }
            else {
                anim.SetBool("Death", true);
                Speed = 0;
                Destroy(this.gameObject, 0.3f);
            }
    
        }
    }

    private void setHitFalse()
    {
        anim.SetBool("Hit", false);
    }

}
