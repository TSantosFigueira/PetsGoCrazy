using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//! Manages shooting
public class Weapon : MonoBehaviour {

    public string shootButton; //!< Reference to player's shoot button 

    public int projectileSpeed;
    public int damage;


	
	void Start () {
		
	}
	
	
	void Update () {
        if (Input.GetButtonDown(shootButton))
        {
            // retrieve from bullets pool
        }
	}
}
