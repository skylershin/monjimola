using System.Collections;
using UnityEngine;
using UnityEngine.UI;
	
public class Health {
	public int startingHealth = 1;
	public static int currentHealth = 1;
	public const int minHealth = 1;
	public const int maxHealth = 6000;

	private HealthListener mListener;

	public static void onAdd(int healthAmount) {
		if (currentHealth + healthAmount <= maxHealth) {
			currentHealth += healthAmount;
		}

		showScore (currentHealth);
		//mListener.onRemoveHealth (currentHealth);
		//health bar
	}

	public static void onRemove(int healthAmount) {
		if (currentHealth - healthAmount >= minHealth) {
			currentHealth -= healthAmount;
		}
		showScore (currentHealth);
	}

	static void showScore(int health) {
		Text scoreText = GameObject.Find ("ScoreText").GetComponent<Text> ();
		scoreText.text = health.ToString();
	}
	/*
	public void addHealthListener(HealthListener healthListener) {
		mListener = healthListener;
	}
	*/
}