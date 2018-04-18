using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLauncher : MonoBehaviour {

	//Singelton

	public float levelStartDelay = 2f;
	public float currentLvlTime;


	private Text levelText;
	private GameObject levelImage;
	private int level;
	private string firstLevel = "level1";

	// Use this for initialization
	void Awaken () {
		startLevel ();

	}



	void HideLevelImage()
	{
		levelImage.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void startLevel(){
		
		levelImage = GameObject.Find ("LevelImage");
		levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		levelText.text = "Level " + level;

		levelImage.SetActive (true);
		Invoke ("HideLevelImage", levelStartDelay);
		SceneManager.LoadScene("level"+level++);
		currentLvlTime = 0;
	
	}


	void finishLevel(){
		
		startLevel ();	
	}
}