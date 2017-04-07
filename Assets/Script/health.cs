using System.Collections;
using UnityEngine;
	
public class Health {
	public int startingHealth = 1;
	public int currentHealth;
	public const int minHealth = 1;

	private HealthListener mListener;

	public void onAdd(int healthAmount) {
		currentHealth += healthAmount;

		//mListener.onRemoveHealth (currentHealth);
		//health bar
	}

	/*
	public void addHealthListener(HealthListener healthListener) {
		mListener = healthListener;
	}
	*/
}