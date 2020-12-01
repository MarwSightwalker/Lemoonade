using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float internGravity;

    public float jumpTime;
    public Rigidbody rb;
    SpriteRenderer sr;

    float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity();
        PlayerMove();
        
    }

    void PlayerMove()
    {
        rb.velocity = (Vector3.right * Input.GetAxis("Horizontal")) + (Vector3.forward * Input.GetAxis("Vertical")) + new Vector3(Input.GetAxis("Horizontal") * speed, rb.velocity.y, Input.GetAxis("Vertical") * speed);
        if(Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
        }
    }

    void Gravity()
    {
        counter += Time.deltaTime;
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            if(counter < jumpTime)
            {
                rb.velocity = new Vector3(rb.velocity.x, internGravity + 0.1f, rb.velocity.z);
            }
            else
            {
                rb.velocity = new Vector3(rb.velocity.x, -internGravity/1.2f, rb.velocity.z);
            }
        }
        else
        {
            rb.velocity = new Vector3(rb.velocity.x, -internGravity, rb.velocity.z);
        }
        Debug.Log(rb.velocity.y);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Floor")
        {
            counter = 0;
        }
    }
}
