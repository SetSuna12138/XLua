using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

///<summary>
///
///</summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float turnSpeed = 100f;
    public float fireTime = 0.5f;
    public float jumpSpeed = 8f;

    private float ver;
    private float hor;
    private bool isGround = true;
    private float timer;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        InputControl();
    }

    private void InputControl()
    {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        

        transform.position += transform.forward * ver * Time.deltaTime * moveSpeed;
        transform.Rotate(transform.up * hor * Time.deltaTime * turnSpeed);

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

        if (Input.GetMouseButton(0))
        {
            if (timer <= 0)
            {
                timer = fireTime;
            }
            else
            {
                timer -= fireTime;
            }
        }
    }

    private void Jump()
    {
        if (!isGround)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            isGround = true;
        }    
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
            isGround = false;
    }
}
