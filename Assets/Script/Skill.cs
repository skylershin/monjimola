using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Skill : MonoBehaviour 
{
	public Image skillFilter;
	public float coolTime;

	private bool canUseSkill = true;

	void start()
	{
		skillFilter.fillAmount = 0;
	}

	public void UseSkill()
	{
		if (canUseSkill)
		{
			skillFilter.fillAmount = 1;
			StartCoroutine("Cooltime");

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