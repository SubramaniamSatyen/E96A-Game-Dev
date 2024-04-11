using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 10.0f;
    private Vector2 direction = Vector2.zero;
    private bool isGrounded = true;
    private Rigidbody rb;

    [SerializeField] private float rotationSpeed = 0.5f;    
    
    [SerializeField] private float cooldownTime = 0.1f;

    private int jumpsLeft = 2;
    // private float lastUsedTime;
    public Vector3 movement;
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        // lastUsedTime = Time.time;
    }

    void Update(){
        Move(direction.x, direction.y);
        if (isGrounded){
            jumpsLeft = 2;
        }
    }

    void OnMove(InputValue value){
        Vector2 v = value.Get<Vector2>();
        this.direction = v;
    }
    
    void OnJump() {
        if (jumpsLeft > 0){
            Debug.Log("Jumping");
            Jump();
            jumpsLeft -= 1;
        }
    }

    // void OnDash() {
    //     if (isGrounded && Time.time > lastUsedTime + cooldownTime){
    //         Dash();
    //         lastUsedTime = Time.time;
    //     }
    // }

    void OnCollisionExit(Collision collision){
        isGrounded = false;
    }

    void OnCollisionStay(Collision collision){
        if (Vector3.Angle(collision.GetContact(0).normal, Vector3.up) < 45f){
            // Debug.Log("Collide - Can Jump");
            isGrounded = true;
        }
        else {
            isGrounded = false;
        }   
    }

    private void Move(float x, float z){
        // Debug.Log(transform.forward * z * speed + transform.right * x * speed + new Vector3(0, rb.velocity.y, 0));
        rb.velocity = transform.forward * z * speed + transform.right * x * speed + new Vector3(0, rb.velocity.y, 0);
    }

    private void Jump(){
        rb.velocity = new Vector3(rb.velocity.x, jumpHeight, rb.velocity.z);
        
    }

    // private void Dash(){
    //     Debug.Log("Dashing");
    //     this.direction = transform. + new Vector3(0, rb.velocity.y, 0);
    // }

    void OnLook(InputValue value){
        Vector2 v = value.Get<Vector2>();
        // Debug.Log(v);

        rb.rotation =  Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(rotationSpeed * v.y * 0f, rotationSpeed * v.x, 0f));

    }
}
