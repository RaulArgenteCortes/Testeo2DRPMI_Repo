using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Referencia a las antiguas inputs
    float horInput;

    // Referencias generales
    [SerializeField] Rigidbody2D playerRb; //Referencia al rigidbody del player

    [Header("Movement Parameters")]
    public float speed;

    [Header("Jump Parameters")]
    public float jumpForce;
    [SerializeField] bool isGrounded;

    void Start()
    {
        // Autoreferenciar componentes: nombre de variable = GetComponent()
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horInput = Input.GetAxis("Horizontal");
        Jump();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        playerRb.velocity = new Vector3(horInput * speed, playerRb.velocity.y, 0);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
