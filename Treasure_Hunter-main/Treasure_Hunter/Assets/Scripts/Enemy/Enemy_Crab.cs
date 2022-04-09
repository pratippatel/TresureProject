using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Crab : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;

    public Transform leftPoint, rightPoint;

    private float leftx, rightx;
    private bool FaceRight = true;
    public float Speed;
    void Start()
    {
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
        if (FaceRight) {
            rb.velocity = new Vector2(Speed, rb.velocity.y);
            if (transform.position.x > rightx)
            {
                transform.localScale = new Vector3(-6, 6, 6);
                FaceRight = false;
            }
        }
        else
        {
            rb.velocity = new Vector2(-Speed, rb.velocity.y);
            if (transform.position.x < leftx)
            {
                transform.localScale = new Vector3(6, 6, 6);
                FaceRight = true;
            }
        }
    }
}
