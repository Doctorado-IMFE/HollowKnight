using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento del personaje
    public float jumpForce = 5f; // Fuerza de salto del personaje

    private Animator animator; // Referencia al componente Animator
    private SpriteRenderer spriteRenderer; // Referencia al componente SpriteRenderer
    private bool isJumping = false; // Variable para controlar si el personaje está saltando

    private void Start()
    {
        animator = GetComponent<Animator>(); // Obtener referencia al componente Animator
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener referencia al componente SpriteRenderer
    }

    private void Update()
    {
        animator.SetTrigger("lintern"); // Activar la animación de lintern
        float moveX = Input.GetAxis("Horizontal"); // Obtener la entrada horizontal (eje X)
        float moveY = Input.GetAxis("Vertical"); // Obtener la entrada vertical (eje Y)

        Vector3 movement = new Vector3(moveX, moveY, 0f); // Crear un vector de movimiento

        transform.position += movement * moveSpeed * Time.deltaTime; // Mover al personaje

        // Actualizar las variables del animator
        animator.SetFloat("MoveX", moveX);
        animator.SetFloat("MoveY", moveY);

        // Cambiar entre las animaciones IDLE, WALK y JUMP
        if (movement.magnitude > 0f && !isJumping)
        {
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        // Cambiar la dirección del sprite según el movimiento
        if (moveX > 0f)
        {
            spriteRenderer.flipX = false; // No voltear el sprite horizontalmente
        }
        else if (moveX < 0f)
        {
            spriteRenderer.flipX = true; // Voltear el sprite horizontalmente
        }

        // Mecánica de salto
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            animator.SetTrigger("Jump"); // Activar la animación de salto

            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);

            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}



