using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM : MonoBehaviour {

	private int repeatTime = 2;
	enum GameTime {Day, Night};
	private GameTime gameTime;

	// Use this for initialization
	void Start () {
		// initial background color
		gameTime = GameTime.Day;
		StartCoroutine (Repeating ());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Repeating() {
		while(true) {
			gameTime = gameTime == GameTime.Day ? GameTime.Night : GameTime.Day;
			changeBackgroundFor (gameTime);

			yield return new WaitForSeconds(repeatTime);
		}
	}

	void changeBackgroundFor(GameTime gameTime) {
		Color dayColor = new Color32 (255, 249, 230, 100);
		Color nightColor = new Color32 (45, 71, 86, 100);
		switch (gameTime) {
		case GameTime.Day: 
			Camera.main.backgroundColor = nightColor;
				break;
		case GameTime.Night:
			Camera.main.backgroundColor = dayColor;
				break;
		}
	}

	public void clickDuster()
	{
		Debug.Log ("Duster");
	}

	public void clickTabaco()
	{
		Debug.Log ("Tabaco");
	}

	public void clickGrilledFish()
	{
		Debug.Log ("GrilledFish");
	}

	public void clickFire()
	{
		Debug.Log ("Fire");
	}

	public void clickCar()
	{
		Debug.Log ("Car");
	}
}
