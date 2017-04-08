using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dust : MonoBehaviour {

	public Image d4;
	public Image d3;
	public Image d2;
	public Image d1;

	void Start () {
		d1 = GameObject.Find ("1").GetComponent<Image> ();
		d2 = GameObject.Find ("2").GetComponent<Image> ();
		d3 = GameObject.Find ("3").GetComponent<Image> ();
		d4 = GameObject.Find ("4").GetComponent<Image> ();
	}

	void Update() {
		checkVisiblity ();
	}

	void checkVisiblity (){
		if (Health.currentHealth < 1000) {
			phaseD1 ();
		} else if (Health.currentHealth < 3000) {
			phaseD2 ();
		} else if (Health.currentHealth < 5000) {
			phaseD3 ();
		} else {
			phaseD4 ();
		}
	}

	void phaseD1() {
		d1.enabled = true;
		d2.enabled = false;
		d3.enabled = false;
		d4.enabled = false;
	}

	void phaseD2() {
		d1.enabled = false;
		d2.enabled = true;
		d3.enabled = false;
		d4.enabled = false;
	}

	void phaseD3() {
		d1.enabled = false;
		d2.enabled = false;
		d3.enabled = true;
		d4.enabled = false;
	}

	void phaseD4() {
		d1.enabled = false;
		d2.enabled = false;
		d3.enabled = false;
		d4.enabled = true;
	}
}
