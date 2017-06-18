using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour {

    public string verticalAxis;
    public Image characterBoard;

    private float vertical;
    private int i = 0;

	void Start () {
		
	}
	
	void Update () {
        vertical = Input.GetAxis(verticalAxis);

        if (vertical > 0)
            characterBoard.sprite = AvailableCharacters.characters.First.Value;
        else if(vertical < 0)
            characterBoard.sprite = AvailableCharacters.characters.Last.Value;


    }
}
