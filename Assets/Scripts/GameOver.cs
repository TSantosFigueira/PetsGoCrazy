using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

    public Image img;
    public Sprite catsWonImg;
    public Sprite dogsWonImg;
    public Sprite drawImg;

    // Use this for initialization
    void Start () {
        if (ScoreManager.winner == "cats") img.sprite = catsWonImg;
        else if (ScoreManager.winner == "dogs") img.sprite = dogsWonImg;
        else { img.sprite = drawImg; }

        img.GetComponent<Image>().SetNativeSize();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
