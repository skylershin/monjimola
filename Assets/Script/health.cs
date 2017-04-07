using System.Collections;
using UnityEngine;

public class health : MonoBehaviour {
	public int startingHealth = 1;
	public int currentHealth;
	public const int minHealth = 1;
	
	public void airCondition(int amount) {
		currentHealth -= amount;

		//health bar
	}
}