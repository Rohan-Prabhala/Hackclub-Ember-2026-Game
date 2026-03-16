using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 400f;

    private Rigidbody2D rb;

    private Vector2 moveInput;

    private bool isTouchingGround = false;
    
    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start() {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        Vector2 normalVector = collision.contacts[0].normal;
        if(Vector2.Dot(normalVector, Vector3.down) < 0f) {
            //collided with the ground
            isTouchingGround = true;
        }

        Debug.Log(Vector2.Dot(normalVector, Vector3.down));
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("foreground"))
            isTouchingGround = false;
        else if (collision.gameObject.CompareTag("soul")) {
            Destroy(collision.gameObject);
            MainSceneManager.Instance.incrementSoulsCounted();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);

        if (isTouchingGround && moveInput.y > 0f)
            rb.AddForce(new Vector2(0, jumpForce));
    }

    public void OnMove(InputValue value) {
        moveInput = value.Get<Vector2>();
    }

}
