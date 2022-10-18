using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbody : MonoBehaviour
{
    public Rigidbody rb;
    public Camera MainCamera;

    public float velocidade = 30f;
    public float JumpForce;

    public LayerMask LayerMask;
    public bool IsGrounded;
    public float GroundedCheckSize;
    public Vector3 GroundCheckPosition;

    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true && IsGrounded == true)
        {
            IsGrounded = false;
            rb.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, rb.velocity.y, vertical);

        rb.velocity = new Vector3(horizontal*velocidade, rb.velocity.y, vertical*velocidade);
    }

    private void OnCollisionStay(Collision collision)
    {
        IsGrounded = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        IsGrounded = false;
    }

}
