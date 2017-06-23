using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{

	void Start () {
        DontDestroyOnLoad(gameObject);
	}
	
	void Update () {
        if (SceneManager.GetActiveScene().buildIndex > 1)
            Destroy(gameObject);
	}
}
