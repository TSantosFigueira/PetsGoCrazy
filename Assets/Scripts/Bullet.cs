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
        if (Weapon.whoShot.Contains("Cat"))
            if (collision.gameObject.name.Contains("Dog")) { 
                collision.gameObject.GetComponent<PlayerMovement>().Die();
                Destroy(this.gameObject);
            } else{ Destroy(this.gameObject); }

        if (Weapon.whoShot.Contains("Dog"))
            if (collision.gameObject.name.Contains("Cat")) {
                collision.gameObject.GetComponent<PlayerMovement>().Die();
                Destroy(this.gameObject);
            } else{ Destroy(this.gameObject); }

    }
}
