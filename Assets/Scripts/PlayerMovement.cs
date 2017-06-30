using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages geneneral player movement
public class PlayerMovement : MonoBehaviour {

    public int life;

    [Header("Player Movement Settings")]
    public string horizontalAxis = "Horizontal"; //!< Reference to player's horizontal axis movement
    [Range(1, 10)]
    public int movementSpeed;       //!< Player movement velocity
  //public string verticalAxis;     //!< Reference to player's vertical axis movement
    

    [Header ("Player Jump Settings")]
    public string jumpButton = "Jump";  //!< Reference to player's jump movement button 
    [Range(1, 100)]
    public int jumpForce = 20;      //!< How high should the player jump
    private Collider2D isGrounded;  //!< Whether or not the player is grounded
    public Transform groundCheck;    //!< A position marking where to check if the player is grounded
    public LayerMask groundLayer;    //!< Reference to the ground layer

    private float maximumX;         //!< Maximum X position player can go
    private float maximumY;         //!< Maximum Y position player can go

    //private bool jump;              //!< Controls if the player is jumping or not
    [HideInInspector]
    public bool isFacingRight = true;     //!< Controls if the player is moving to the right

    public SpriteRenderer sprite;

    [Header("Explosion assets")]
    public GameObject bloodPrefab;
    public GameObject bonesPrefab;

    void Start()
    {
        Vector3 cameraSize = Camera.main.ScreenToWorldPoint(new Vector3 (Camera.main.transform.position.x, 
                                                                            Camera.main.transform.position.y,
                                                                            Camera.main.transform.position.z));

        maximumX = -cameraSize.x - (sprite.size.x / 2);
        maximumY = -cameraSize.y - (sprite.size.y / 2);
    }

    void Update()
    {
        // Checks if player is grounded by drawing a circle around it and checking overlapping objects on ground layer
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.15f, groundLayer);
        if (Input.GetButtonDown(jumpButton) && isGrounded) { 
            StartCoroutine("Jump");
        }
    }

    void FixedUpdate() {
        if (this.GetComponent<Rigidbody2D>().velocity.x != 0) this.GetComponent<Animator>().SetBool("Walking", true);
        else { this.GetComponent<Animator>().SetBool("Walking", false); }
        print("velox y: " + this.GetComponent<Rigidbody2D>().velocity.y);
        if(!this.isGrounded) this.GetComponent<Animator>().SetBool("Jumped", true);
        else { this.GetComponent<Animator>().SetBool("Jumped", false); }

        float horizontal = Input.GetAxis(horizontalAxis);
    
        Vector2 movement = new Vector2(horizontal, this.GetComponent<Rigidbody2D>().velocity.y);
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (movement.x * movementSpeed, this.GetComponent<Rigidbody2D>().velocity.y);

        if (horizontal > 0 && !isFacingRight)
            FlipPlayer();
        else if (horizontal < 0 && isFacingRight)
            FlipPlayer();

        gameObject.GetComponent<Rigidbody2D>().position = new Vector3(Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().position.x,
                                                                       -maximumX, maximumX),

                                                                      Mathf.Clamp(gameObject.GetComponent<Rigidbody2D>().position.y,
                                                                      -maximumY, maximumY), 0);

        if (this.life <= 0) Die();
    }
    
    IEnumerator Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sounds>().playSound("Jump", .5f);
        this.GetComponent<Animator>().SetBool("Jumped", true);

        yield return new WaitForSeconds(0.25f);

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GetComponent<Rigidbody2D>().gravityScale = 5;
        //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -jumpForce), ForceMode2D.Impulse);
    }

    private void FlipPlayer()
    {
        isFacingRight = !isFacingRight;
        Vector2 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public void Die()
    {
        StartCoroutine("Respawn");
    }

    IEnumerator Respawn () {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        this.GetComponent<Weapon>().enabled = false;
        life = 2;

        GameObject blood = Instantiate(bloodPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -10), Quaternion.identity);
        GameObject bones = Instantiate(bonesPrefab, new Vector3(this.transform.position.x, this.transform.position.y, -10), Quaternion.identity);

        yield return new WaitForSeconds(2);
        if (gameObject.name.Contains("Dog")) {
            transform.position = GameObject.Find("GameManager").GetComponent<GameManager>().dogSpawnPoint.position;
            ScoreManager.catPoints += 100;
            gameObject.SetActive(true);
        }
        else {
            transform.position = GameObject.Find("GameManager").GetComponent<GameManager>().catSpawnPoint.position;
            ScoreManager.dogPoints += 100;
            gameObject.SetActive(true);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<BoxCollider2D>().enabled = true;
        this.GetComponent<Weapon>().enabled = true;
        Destroy(blood.gameObject);
        Destroy(bones.gameObject);
    }
}
