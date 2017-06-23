using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Sound player */

[RequireComponent(typeof (AudioSource))]
public class Sounds : MonoBehaviour {

    private AudioSource source;
    public string[] gameKeys;
    public AudioClip[] gameSounds;

    private Dictionary<string, AudioClip> soundsDict = new Dictionary<string, AudioClip>();

	void Start () {
        source = GetComponent<AudioSource>();

        // Retrieves audio from two arrays to create a dictionary
        if (gameKeys.Length > 0 && gameSounds.Length > 0 && gameSounds.Length == gameKeys.Length)
        {
            for (int i = 0; i < gameSounds.Length; i++)
            {
                soundsDict.Add(gameKeys[i], gameSounds[i]);
            }
        }
	}

    /* Plays sound according to key */
    public void playSound(string key, float volume)
    {
        source.PlayOneShot(soundsDict[key], volume);
    }
}
