using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Responsible for managing bullet effects like damage
public class Bullet : MonoBehaviour {

    [Range(1, 5)]
    public int duration;

	void Start () {
        Destroy(gameObject, duration);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<PlayerMovement>().Die();
        
    }
}
