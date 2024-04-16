using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 10.0f;
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.zero;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move(direction.x);
    }

    void OnMove(InputValue value){
        Vector2 v = value.Get<Vector2>();
        if (v.x < 0) {
            this.GetComponent<SpriteRenderer>().flipX = false;
        }
        else {
            this.GetComponent<SpriteRenderer>().flipX = true;
        }
        this.direction = v;
    }

    void OnJump() {
        if (isGrounded){
            Jump();
        }
    }

    void OnCollisionExit2D(Collision2D collision){
        Debug.Log("Leave Collision");
        isGrounded = false;
    }

    void OnCollisionStay2D(Collision2D collision){
        Debug.Log("Stay Collision");
        isGrounded = true;
    }

    private void Move(float x){
        rb.velocity = new Vector2(x * speed, rb.velocity.y);
    }

    private void Jump(){
        rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
    }
}
