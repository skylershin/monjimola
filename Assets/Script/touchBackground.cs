using System.Collections;
using UnityEngine;

public class touchBackground : MonoBehaviour {
	public int tapDamage = 50;
	private health health;

	// Use this for initialization
	void Start () {
		health = new health ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			health.airCondition (tapDamage);
			Debug.Log ("탭ㅐㅂ탭");
			Debug.Log (tapDamage);
		}
	}
}