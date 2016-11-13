﻿using UnityEngine;
using System.Collections;

public class WorldControlManager : MonoBehaviour {

	public const int HEAVEN = 0;
	public const int EARTH = 1;
	public const int HELL = 2;

	public static bool heavenEnabled;
	public static bool earthEnabled;
	public static bool hellEnabled;

	public AudioClip changeSound;
	public AudioClip playerDeathSound;
	private AudioSource source;

	public static int enabledWorld = EARTH;

	// Use this for initialization
	void Start () {
		source = GetComponent<AudioSource> ();
		heavenEnabled = true;
		hellEnabled = true;
		earthEnabled = true;
	}

	public void PlayPlayerDeathSound(){
		source.PlayOneShot (playerDeathSound);
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (enabledWorld == EARTH || enabledWorld == HELL) {
				enabledWorld--;
				source.PlayOneShot (changeSound);
			}
		}
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			if (enabledWorld == HEAVEN || enabledWorld == EARTH) {
				enabledWorld++;
				source.PlayOneShot (changeSound);
			}
		}
		*/
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

		if (enabledWorld == HEAVEN) {
			if (!earthEnabled && !hellEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !hellEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && earthEnabled)) {
				enabledWorld = EARTH;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && hellEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !earthEnabled)) {
				enabledWorld = HELL;
				source.PlayOneShot (changeSound);
			}
		} else if (enabledWorld == EARTH){
			if (!heavenEnabled && !hellEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && heavenEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !hellEnabled)) {
				enabledWorld = HEAVEN;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !heavenEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && hellEnabled)) {
				enabledWorld = HELL;
				source.PlayOneShot (changeSound);
			}
		} else if (enabledWorld == HELL){
			if (!earthEnabled && !heavenEnabled) {
				return;
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && earthEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && !heavenEnabled)) {
				enabledWorld = EARTH;
				source.PlayOneShot (changeSound);
			}
			if ((Input.GetKeyDown (KeyCode.UpArrow) && !earthEnabled) || (Input.GetKeyDown(KeyCode.DownArrow) && heavenEnabled)) {
				enabledWorld = HEAVEN;
				source.PlayOneShot (changeSound);
			}
		}
	}
}
