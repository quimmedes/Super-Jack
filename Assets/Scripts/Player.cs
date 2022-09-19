using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigibody2d;
    private Collider2D collider2d;
    private float horizontal;
    public float speed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2;
    public bool isJump = false;
    // Start is called before the first frame update




    private void Awake()
    {
        rigibody2d = GetComponent<Rigidbody2D>();
        collider2d = GetComponent<Collider2D>();
        
        rigibody2d.velocity = Vector2.zero;
        


    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }

        horizontal = Input.GetAxisRaw("Horizontal");


       

    }




    // Update is called once per frame
    private void FixedUpdate()
    {

        if (horizontal < 0)

            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);


        rigibody2d.velocity = new Vector2(horizontal * speed, rigibody2d.velocity.y);






        if (isJump)
        {
            if (Grounded())
            {
                rigibody2d.velocity += Vector2.up * jumpForce;
                isJump = false;   
            }
        }




        Debug.DrawRay(transform.position, Vector2.down, Color.red);


        if (rigibody2d.velocity.y < 0)
        {
            Debug.Log("Entrou no primeiro");
            rigibody2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) ;
        }

        else if (rigibody2d.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            Debug.Log("Entrou no segundo");

            rigibody2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) ;
        }




    }

     bool Grounded() {

        return Physics2D.Raycast(transform.position,Vector2.down, collider2d.bounds.extents.y );
    }



       

  


}
