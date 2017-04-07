using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GM : MonoBehaviour {

	// 하루는 240
	private const int REPEAT_TIME = 1;
	private int elapsedTime = 0;

	enum GameTime {Day, Night};
	enum EventTime {Purifier, Plant, Rain}
	private GameTime gameTime;

	private Image eventMessageView;
	private Text eventTextView;
	private Image eventIconView;
	private int eventMessageShowTime=0;
	private int eventMessageViewDuration = 0;
	private int dataOrder = 0;
	private ArrayList data;

	// Use this for initialization
	void Start () {
		eventMessageView = GameObject.Find ("EventMessageView").GetComponent<Image> ();
		eventTextView = GameObject.Find ("MessageTextView").GetComponent<Text> ();
		eventIconView = GameObject.Find ("MessageIconView").GetComponent<Image> ();
		data = new ArrayList ();
		Sprite airSprite = Resources.Load ("EventMessage/icon_air", typeof(Sprite)) as Sprite;
		data.Add (new KeyValuePair<Sprite, string> (airSprite, "엄마가 ‘공기청정기’를 틀었어요!"));
		data.Add (new KeyValuePair<Sprite, string> (Resources.Load ("EventMessage/icon_tree", typeof(Sprite)) as Sprite, "누군가 ‘나무’를 심어 지구를 보호했어요!"));
		data.Add (new KeyValuePair<Sprite, string> (Resources.Load ("EventMessage/icon_rain", typeof(Sprite)) as Sprite, "으앙, ‘비’가 오고있어요!"));

		setEventMessageViewEnabled (false);

		// initial background color
		gameTime = GameTime.Day;
		StartCoroutine (Repeating ());	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Repeating() {
		while(true) {
			elapsedTime += REPEAT_TIME;
			eventMessageViewDuration += REPEAT_TIME;

			handleTimeEvent ();
			yield return new WaitForSeconds(REPEAT_TIME);
		}
	}

	void setEventMessageViewEnabled(bool enabled) {
		eventMessageView.enabled = enabled;
		eventTextView.enabled = enabled;
		eventIconView.enabled = enabled;

		if (enabled) {
			eventMessageViewDuration = 0;
		} else {
			int rInt = Random.Range(4, 10);
			eventMessageShowTime = rInt; 
		}
	}

	void handleTimeEvent() {
		if (elapsedTime % eventMessageShowTime * REPEAT_TIME == 0) {
			KeyValuePair<Sprite, string> pair = (KeyValuePair<Sprite, string>)data [dataOrder];
			changeMessageIcon (pair.Key);
			changeMessageText (pair.Value);

			dataOrder += 1;
			if (dataOrder > 2) 
				dataOrder -= 3;

			setEventMessageViewEnabled (true);
		}

		changeBackgroundFor (elapsedTime);

		if (eventMessageViewDuration == 3) {
			setEventMessageViewEnabled (false);
		}
	}

	void changeMessageIcon(Sprite sprite) {
		GameObject.Find ("MessageIconView").GetComponent<Image> ().sprite = sprite;
	}

	void changeMessageText(string text) {
		GameObject.Find ("MessageTextView").GetComponent<Text> ().text = text;
	}

	void changeBackgroundFor(int elapsedTime) {
		if (elapsedTime % 20 == 0) {
			gameTime = gameTime == GameTime.Day ? GameTime.Night : GameTime.Day;
		}

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
}
