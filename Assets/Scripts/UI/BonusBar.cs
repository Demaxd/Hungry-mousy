using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusBar : MonoBehaviour
{

	private Image img;

	private float duration;
	private void Awake()
	{
		duration = Bonus.Duration;
		img = GetComponent<Image>();
	}
	private void OnEnable()
	{
		StartCoroutine(DecreaseBar());
	}

	IEnumerator DecreaseBar()
	{
		img.fillAmount = 1f;
		float step = img.fillAmount / duration;
		while(img.fillAmount > 0)
		{
			yield return new WaitForSeconds(1f);
			img.fillAmount -= step;
		}
		gameObject.SetActive(false);
		yield break;
	}
}