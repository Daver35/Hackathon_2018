using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	//Singelton
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.

	public float levelStartDelay = 2f;


	private Text levelText;
	private GameObject levelImage;
	private bool doingSetup;
	private int level;

	// Use this for initialization
	void Awaken () {

		//Check if instance already exists
		if (instance == null)

			//if not, set instance to this
			instance = this;

		//If instance already exists and it's not this:
		else if (instance != this)

			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy(gameObject);    

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);


	}


	// Is level loaded?
	private void OnLevelWasLoaded(int index)
	{
		InitGame ();
	}

	void InitGame()
	{
		doingSetup = true;

		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		levelText.text = "Level " + level;

		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);

	}

	void HideLevelImage()
	{
		levelImage.SetActive (false);
		doingSetup = false;
	}











	// Update is called once per frame
	void Update () {
		
	}
}
