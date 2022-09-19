using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigidbody;
    public float speed;
    public float side = -1.0f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        rigidbody.velocity = new Vector2(side * speed, rigidbody.velocity.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        side *= -1;
    }


}
