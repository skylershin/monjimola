﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill: MonoBehaviour 
{
	public Image skillFilter;
	public float coolTime;

	public int skillDamage;
	private Health health;
	 
	private bool canUseSkill = true;

	void start()
	{
		skillFilter.fillAmount = 0;
	}

	void update()
	{
		if (Input.anyKeyDown) {
			UseSkill ();
		}
	}

	public void UseSkill()
	{
		if (canUseSkill)
		{
			skillFilter.fillAmount = 1;
			StartCoroutine("Cooltime");
			Health.onAdd (skillDamage); 

			canUseSkill = false;

			Debug.Log ("스킬 사용");
		}
	}

	IEnumerator Cooltime()
	{
		while(skillFilter.fillAmount > 0)
		{
			skillFilter.fillAmount -= 1 * Time.smoothDeltaTime / coolTime;

			yield return null;
		}

		canUseSkill = true;
		yield break;
	}
}