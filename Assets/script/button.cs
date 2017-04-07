using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class button : MonoBehaviour {

	public Button next;
	// Use this for initialization
	void Start () {
		Button btn = next.GetComponent<Button> ();
		btn.onClick.AddListener (onClickButton);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onClickButton() {
		Debug.Log("You have clicked the button!");
	}
}
