using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface HealthListener {
	void onAddHealth (int currentHealth);
	void onRemoveHealth (int currentHealth);
}
