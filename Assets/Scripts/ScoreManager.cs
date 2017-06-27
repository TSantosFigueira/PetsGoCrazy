using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    public static int catPoints;
    public static int dogPoints;
    public Text catPointsTxt;
    public Text dogPointsTxt;

    public static string winner;
    
    void Start () {
        catPoints = dogPoints = 0;
    }
	
	void Update () {
        catPointsTxt.text = catPoints.ToString();
        dogPointsTxt.text = dogPoints.ToString();
        if (catPoints > dogPoints) winner = "cats";
        else if (catPoints < dogPoints) winner = "dogs";
        else { winner = ""; }
    }
}
