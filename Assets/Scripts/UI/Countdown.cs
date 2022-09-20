using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
	private Text countText;
	private Animation anim;
	private AudioSource src;

	private void Awake()
	{
		countText = GetComponent<Text>();
		anim = GetComponent<Animation>();
		src = GetComponent<AudioSource>();
	}

	private IEnumerator Start()
	{
		src.Play();
		for(int i = 3; i > 0; i--)
		{
			countText.text = i.ToString();
			anim.Play();
			yield return new WaitForSeconds(0.85f);
		}
		countText.text = "Go!";
		anim.Play();
		yield return new WaitForSeconds(0.7f);
		gameObject.SetActive(false);
		yield break;
	}
}