using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour {

    public Transform catSpawnPoint;
    public Transform dogSpawnPoint;

    public Sprite[] characterBoard;
    public GameObject[] characters;
    private string[] controllers = new string[] { "_P1", "_P2", "_P3", "_P4" };

	void Start () {

        for (int i = 1; i < 5; i++)
        {
            string player = PlayerPrefs.GetString("Player" + i.ToString());
            if (player != null)
            {
                for (int j = 0; j < characterBoard.Length; j++)
                {
                    if( player == characterBoard[j].name)
                    {
                        characters[j].GetComponent<PlayerMovement>().horizontalAxis = "Horizontal" + controllers[i - 1]; //como i começa em 1, para compensar
                        characters[j].GetComponent<PlayerMovement>().jumpButton = "Jump" + controllers[i - 1];
                        characters[j].GetComponent<Weapon>().shootButton = "Fire" + controllers[i - 1];

                        if (characters[j].name.Contains("Dog"))
                        {                     
                            Instantiate(characters[j], dogSpawnPoint.position, Quaternion.identity);
                        }
                        else
                        {             
                            Instantiate(characters[j], catSpawnPoint.position, Quaternion.identity);
                        }
                    }
                }
            }
        }
	}
}
