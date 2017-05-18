using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages geneneral player movement
public class PlayerMovement : MonoBehaviour {

    [Header("Player Movement Settings")]
    public string horizontalAxis = "Horizontal"; //!< Reference to player's horizontal axis movement
    [Range(1, 10)]
    public int movementSpeed;       //!< Player movement velocity
  //public string verticalAxis;     //!< Reference to player's vertical axis movement
    

    [Header ("Player Jump Settings")]
    public string jumpAxis = "Jump";  //!< Reference to player's jump movement button 
    [Range(10, 100)]
    public int jumpForce = 20;      //!< How high should the player jump
    private Collider2D isGrounded;  //!< Whether or not the player is grounded
    public Transform groundCheck;    //!< A position marking where to check if the player is grounded
    public LayerMask groundLayer;    //!< Reference to the ground layer

    private float maximumX;         //!< Maximum X position player can go
    private float maximumY;         //!< Maximum Y position player can go

    private bool jump;

    public SpriteRenderer sprite;

    void Start()
    {
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.transform.position.x, 
                                                                            Camera.main.transform.position.y,
                                                                            Camera.main.transform.position.z));

        maximumX = -cameraSize.x - sprite.size.x;
        maximumY = -cameraSize.y - sprite.size.y;
    }

    void Update()
    {
        // Checks if player is grounded by drawing a circle around it and checking overlapping objects on ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f, groundLayer);
        if (Input.GetButtonDown(jumpAxis) && isGrounded)
            jump = true;
    }

    void FixedUpdate()
    {

        float horizontal = Input.GetAxis(horizontalAxis);
        // float vertical = Input.GetAxis(verticalAxis);

        Vector2 movement = new Vector2(horizontal, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement * movementSpeed;


        //transform.position.x = Mathf.Clamp(transform.position.x, -maximumX, maximumX);

        gameObject.GetComponent<Rigidbody2D>().position = new Vector3(Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().position.x,
                                                                       -maximumX, maximumX),

                                                                      Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().position.y,
                                                                      -maximumY, maximumY), 0);
        if (jump)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            jump = false;
        }
    }
}
