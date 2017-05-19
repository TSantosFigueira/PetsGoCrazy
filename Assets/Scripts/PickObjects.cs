using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manages objects pick and drop by player
/// </summary>
public class PickObjects : MonoBehaviour {

    public string pickButton = "Fire2";
    public float pickUpDistance = 1f;
    public LayerMask objectsLayer;

    private Transform carriedObject = null;
    
	void Update () {

        if (Input.GetButtonDown(pickButton))
        {
            if (carriedObject != null)
                Drop();
            else
                PickUp();
        }
	}

    private void Drop()
    {
        carriedObject.parent = null; // Unparent picked object
        carriedObject.gameObject.AddComponent(typeof(Rigidbody2D)); // Gives the object gravity and co.
        carriedObject = null;  // Enables possibility for picking up another object
    }

    private void PickUp()
    {
        // Detects all pickable objects around player, given the radius
        Collider2D[] picks = Physics2D.OverlapCircleAll(transform.position, pickUpDistance, objectsLayer);


        float auxiliaryDistance = Mathf.Infinity;
        for (int i = 0; i < picks.Length; i++)
        {
            float newDist = (transform.position - picks[i].transform.position).sqrMagnitude; // Checks for closest object

            if (newDist < auxiliaryDistance)
            {
                carriedObject = picks[i].transform;
                auxiliaryDistance = newDist;
            }
        }

        if(carriedObject != null)
        {
            Destroy(carriedObject.GetComponent<Rigidbody2D>());
            carriedObject.parent = transform;
            carriedObject.localPosition = Vector2.zero;
        }
    }
}
