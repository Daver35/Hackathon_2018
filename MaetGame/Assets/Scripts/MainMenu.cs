using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//Go to 1st level: SceneMaanager.LoadScene(newGameScene);
	public void Play(string newGameScene){
		SceneManager.LoadScene (newGameScene);
	}

	//Exit game
	public void Quit(){
		Application.Quit ();
	}
}
