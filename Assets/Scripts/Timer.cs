using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {
    public int time;
    public Text timeTxt;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CountTime", 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        timeTxt.text = time.ToString();

        if (Input.GetButton("Start_P1")) {
            if (Input.GetButtonDown("Select")) SceneManager.LoadScene(0);
        }
    }

    void CountTime() {
        time -= 1;
        if (time < 25) timeTxt.color = GameObject.Find("GameManager").GetComponent<ScoreManager>().catPointsTxt.color;
        if (time <= 0) {
            SceneManager.LoadScene(4);
        }

    }
}
