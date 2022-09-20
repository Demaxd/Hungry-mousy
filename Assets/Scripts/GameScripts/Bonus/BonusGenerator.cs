using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusGenerator : MonoBehaviour
{
	[SerializeField]
	private Difficulty diff;

	[SerializeField]
	private Transform respawnpoint;

	[SerializeField]
	private Bonus bonus_prefab;

	[SerializeField]
	private GameObject player;

	private Renderer rend;


	private Bonus bonus;

	[SerializeField]
	private GameObject bar;

	private AudioSource src;

	private int interval;
	private float duration;
	private float speed;

	private void Start()
	{
		rend = player.GetComponentInChildren<Renderer>();
		rend.material.DisableKeyword("_EMISSION");
		src = GetComponent<AudioSource>();
		duration = Bonus.Duration;
		StartCoroutine(SpawnRoutine());
		bonus = Instantiate(bonus_prefab, transform);
		bonus.gameObject.SetActive(false);
	}

	private void Update()
	{
		speed = diff.SpeedZ;
		Translate();
	}

	private IEnumerator SpawnRoutine()
	{
		while (true)
		{
			interval = Random.Range(10, 15);
			yield return new WaitForSeconds(interval);
			bonus.transform.position = new Vector3(SelectLane(), 25f, respawnpoint.position.z);
			bonus.gameObject.SetActive(true);
		}
	}
	private void Translate()
	{
		bonus.transform.Translate(speed * Vector3.back * Time.deltaTime);
		if (bonus.transform.position.z <= -110f) bonus.gameObject.SetActive(false);
	}

	public void Boost() => StartCoroutine(BoostRoutine());

	private IEnumerator BoostRoutine()
	{
		src.Play();
		bar.SetActive(true);

		rend.material.EnableKeyword("_EMISSION");

		ScoreCounter.CurrentColor = Color.yellow;
		ScoreCounter.Multiplier = 2;

		yield return new WaitForSeconds(duration);


		rend.material.DisableKeyword("_EMISSION");
		ScoreCounter.CurrentColor = Color.black;
		ScoreCounter.Multiplier = 1;
		yield break;

	}

	private int SelectLane()
	{
		var value = Random.Range(0, 3);
		if (value == 0) return -10;
		else if (value == 1) return 0;
		else return 10;
	}
}
