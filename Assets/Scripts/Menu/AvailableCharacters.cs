using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableCharacters : MonoBehaviour {

    public Sprite[] character;
    public static LinkedList<Sprite> characters = new LinkedList<Sprite>();

    void Start () {
        for (int i = 0; i < character.Length; i++)
        {
            characters.AddLast(character[i]);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
