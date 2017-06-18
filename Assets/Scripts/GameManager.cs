﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform catSpawnPoint;
    public Transform dogSpawnPoint;

    public Sprite[] characterBoard;
    public GameObject[] characters;

	void Start () {

        for (int i = 1; i < 5; i++)
        {
            string player = PlayerPrefs.GetString("Player" + i.ToString());
            if (player != null)
            {
                for (int j = 0; j < characterBoard.Length; j++)
                {
                    if(player == characterBoard[j].name)
                    {
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
	
	// Update is called once per frame
	void Update () {
		
	}
}