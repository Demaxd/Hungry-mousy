using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{

	private static float duration = 10;

	public static float Duration { get { return duration; } }

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			GetComponent<AudioSource>().Play();
			transform.parent.gameObject.GetComponent<BonusGenerator>().Boost();
			gameObject.SetActive(false);
		}
	}
}