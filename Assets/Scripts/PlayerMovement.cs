using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages geneneral player movement
public class PlayerMovement : MonoBehaviour {

    [Header("Player Movement Settings")]
    public string horizontalAxis;    //!< Reference to player's horizontal axis movement
    [Range(1, 10)]
    public int movementSpeed;       //!< Player movement velocity
  //public string verticalAxis;     //!< Reference to player's vertical axis movement
    

    [Header ("Player Jump Settings")]
    public string jumpAxis;          //!< Reference to player's jump movement button 
    private bool isGrounded = true;  //!< Whether or not the player is grounded
    public Transform groundCheck;    //!< A position marking where to check if the player is grounded
    public LayerMask groundLayer;    //!< Reference to the ground layer

	
	void FixedUpdate () {

        float horizontal = Input.GetAxis(horizontalAxis);
       // float vertical = Input.GetAxis(verticalAxis);

        Vector2 movement = new Vector2(horizontal, 0);
        gameObject.GetComponent<Rigidbody2D>().velocity = movement * movementSpeed;

        // Checks if player is grounded by drawing a circle around it and checking overlapping objects on ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);

        if (Input.GetButtonDown(jumpAxis) && isGrounded)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        }
	}
}
