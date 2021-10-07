using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 startPos;
    private float speed;
    private float dirX;
    private float jump = 15.0f;
    private float gravityM = 1.1f;
    private bool grounded = false;
    private bool muddy = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 20.0f;

        rb = GetComponent<Rigidbody>();

        startPos = (gameObject.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * speed;

        if(muddy)
        {
            speed = 5.0f;
        }
        else
        {
            speed = 20.0f;
        }

        if(grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jump, ForceMode.VelocityChange);
            grounded = false;
        }
        else if(muddy && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * (jump - 10.0f), ForceMode.VelocityChange);
            muddy = false;
        }
    }

    void FixedUpdate()
    {
        if(!grounded)
        {
            rb.AddForce(Physics.gravity * gravityM, ForceMode.Acceleration);
        }

        rb.velocity = new Vector3(dirX, rb.velocity.y, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if(ground)
        {
            grounded = true;
        }

        Mud mud = collision.gameObject.GetComponent<Mud>();
        if(mud)
        {
            muddy = true;
        }

        Death death = collision.gameObject.GetComponent<Death>();
        if(death)
        {
            gameObject.transform.position = startPos;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Ground ground = collision.gameObject.GetComponent<Ground>();
        if(ground)
        {
            grounded = false;
        }

        Mud mud = collision.gameObject.GetComponent<Mud>();
        if(mud)
        {
            muddy = false;
        }
    }
}
