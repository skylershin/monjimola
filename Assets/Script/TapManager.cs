using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapManager : MonoBehaviour {
	private Health health;
	public const int tapDamage = 50;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		int count = Input.touchCount;

		for( int i = 0 ; i < count ; i++ ){
			Touch touch = Input.GetTouch(i);
			Debug.Log ("tapping");
			Debug.Log (Health.currentHealth);

			if (touch.phase == TouchPhase.Began) {
				// Construct a ray from the current touch coordinates

				Health.onAdd (tapDamage);
				Debug.Log ("tapping");
				Debug.Log (Health.currentHealth);

			}
		}
	}
}
