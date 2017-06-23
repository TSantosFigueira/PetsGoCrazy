using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages shooting
public class Weapon : MonoBehaviour {

    public string shootButton;     //!< Reference to player's shoot button 
    public GameObject projectile;  //!< The bullet that will be shot from this weapon

    [Range(1, 20)]
    public int damage;             //!< Bullet damage will cause to player and other objects
    [Range(1, 20)]
    public int velocity;           //!< Bullet velocity at start

    [Range(1, 5)]
    public float delayTime;        //<! Time between every shot
    private float timer;           //<! Internal timer controller
	
	void Start () {
		
	}
	
	void Update () {
        timer -= Time.deltaTime;

        if (Input.GetButtonDown(shootButton) && timer <= 0f)
        {
            GameObject.FindGameObjectWithTag("SoundManager").GetComponent<Sounds>().playSound("Shoot", .5f);
            timer = delayTime;
            if (GetComponentInParent<PlayerMovement>().isFacingRight)
            {
                GameObject bullet = Instantiate(projectile, transform.position + new Vector3(1, 0), Quaternion.Euler(Vector3.zero));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity, 0), ForceMode2D.Impulse);
            }
            else
            {
                GameObject bullet = Instantiate(projectile, transform.position + new Vector3(-1, 0), Quaternion.Euler(new Vector2(0, 180)));
                bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocity, 0), ForceMode2D.Impulse);
            }
        }
	}
}
