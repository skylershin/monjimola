using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GM : MonoBehaviour {

	private const int REPEAT_TIME = 1;
	private int elapsedTime =0;
	enum GameTime {Day, Night};
	private GameTime gameTime;

	private Image eventMessageView;
	private Text eventTextView;
	private Image eventIconView;

	private int eventMessageShowTime=0;
	private int eventMessageDuration=0;
	private int eventMessageOrder = 0;
	private ArrayList eventMessages;
	//TODO healthbar gameobject 

	// Use this for initialization
	void Start () {
		eventMessageView = GameObject.Find ("EventMessage").GetComponent<Image> ();
		eventTextView = GameObject.Find ("MessageText").GetComponent<Text> ();
		eventIconView = GameObject.Find ("MessageIcon").GetComponent<Image> ();

		eventMessages = new ArrayList ();
		eventMessages.Add (
			new KeyValuePair<Sprite, string> (
				Resources.Load ("eventMessage/icon_air", typeof(Sprite)) as Sprite,
				"엄마가 ‘공기청정기’를 틀었어요!"));
		eventMessages.Add (
			new KeyValuePair<Sprite, string> (
				Resources.Load ("eventMessage/icon_tree", typeof(Sprite)) as Sprite,
				"누군가 ‘나무’를 심어 지구를 보호했어요!"));
		eventMessages.Add (
			new KeyValuePair<Sprite, string> (
				Resources.Load ("eventMessage/icon_rain", typeof(Sprite)) as Sprite,
				"으앙, ‘비’가 오고있어요!"));
		setEventMessageViewEnabled (false);
		// initial background color
		gameTime = GameTime.Day;
		StartCoroutine (Repeating ());	

		//health
	}
	
	// Update is called once per frame
	public void Update () {
		//touch input
		if(Input.anyKeyDown) {
			int x = (int)Input.mousePosition.x;
			int y = (int)Input.mousePosition.y;
			Debug.Log ("x="+x);
			Debug.Log ("y=" + y);

			if (isInsideDust (x, y)) {
				onClickDust ();
			} else if (isInsideTabaco (x, y)) {
				onClickTabaco ();
			} else if (isInsideGrilledFish (x, y)) {
				onClickGrilledFish ();
			} else if (isInsideFire (x, y)) {
				onClickFire ();
			} else if (isInsideCar (x, y)) {
				onClickCar ();
			} else if (isInsideMain (x, y)) {
				onClickMain ();
			}	
		}
	}

	bool isInsideMain(int x, int y) {
		int leftX = 55;
		int rightX = 290;
		int topY = 420;
		int bottomY = 120;

		return x >= leftX && x <= rightX && y >= bottomY && y <= topY;
	}

	bool isInsideDust(int x, int y) {
		return calculateInsideBottomButton (x, y, 75, 95);
	}

	bool isInsideTabaco(int x, int y) {
		return calculateInsideBottomButton (x, y, 125, 95);
	}

	bool isInsideGrilledFish(int x, int y) {
		return calculateInsideBottomButton (x, y, 175, 95);
	}

	bool isInsideFire(int x, int y) {
		return calculateInsideBottomButton (x, y, 225, 95);
	}

	bool isInsideCar(int x, int y) {
		return calculateInsideBottomButton (x, y, 275, 95);
	}

	bool calculateInsideBottomButton(int x, int y, int centerX, int centerY) {
		int leftX = centerX - 15;
		int rightX = centerX + 15;
		int topY = centerY + 15;
		int bottomY = centerY - 15;

		return x >= leftX && x <= rightX && y >= bottomY && y <= topY;
	}

	IEnumerator Repeating() {
		while(true) {
			elapsedTime += REPEAT_TIME;
			eventMessageDuration += REPEAT_TIME;

			handleTimeEvent ();
			yield return new WaitForSeconds(REPEAT_TIME);
		}
	}

	void setEventMessageViewEnabled(bool enabled) {
		eventMessageView.enabled = enabled;
		eventTextView.enabled = enabled;
		eventIconView.enabled = enabled;

		if (enabled) {
			eventMessageDuration = 0;
		} else {
			int rInt = Random.Range (4, 10);
			eventMessageShowTime = rInt;
		}
	}

	void handleTimeEvent() {
		if (elapsedTime % eventMessageShowTime * REPEAT_TIME == 0) {
			if (eventMessageOrder == 0) {
				Health.onRemove (10);
			} else if (eventMessageOrder == 1) {
				Health.onRemove (20);
			} else if (eventMessageOrder == 2) {
				Health.onRemove (15);
			}
			KeyValuePair<Sprite, string> pair = (KeyValuePair<Sprite, string>)eventMessages [eventMessageOrder];
			changeMessageIcon (pair.Key);
			changeMessageText (pair.Value);

			eventMessageOrder += 1;
			if (eventMessageOrder > 2) 
				eventMessageOrder -= 3;

			setEventMessageViewEnabled (true);
		}

		changeBackgroundFor (elapsedTime);

		if (eventMessageDuration == 3) {
			setEventMessageViewEnabled (false);
		}
	}

	void changeMessageIcon(Sprite sprite) {
		eventIconView.sprite = sprite;
	}

	void changeMessageText(string text) {
		eventTextView.text = text;
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
		
	public void onClickDust() {
		Health.onAdd (15);
	}

	public void onClickTabaco()
	{
		Health.onAdd (5);
	}

	public void onClickGrilledFish()
	{
		Health.onAdd (20);
	}

	public void onClickFire()
	{
		Health.onAdd (10);
	}

	public void onClickCar()
	{
		Health.onAdd (30);
	}

	public void onClickMain() {
		Health.onAdd (50);
	}
}
