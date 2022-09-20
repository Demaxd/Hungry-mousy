using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
	[SerializeField]
	private Difficulty diff;
	[SerializeField]
	private GameObject _tunnel, _mousetrap, _insect;


	[SerializeField]
	private GameObject[] _tunnels;

	private GameObject[] _traps;
	private GameObject[] _insects;



	private int _obstCount;
	private float speed;

	private void Awake()
	{
		_obstCount = 20;

		_traps = new GameObject[_obstCount];
		_insects = new GameObject[_obstCount];

		Fill(_traps, _mousetrap);
		Fill(_insects, _insect);

	}
	private void Update()
	{
		speed = diff.SpeedZ;
		Move(_tunnels);
		Move(_traps);
		if (speed > 150f) Move(_insects);
	}

	private void Fill(GameObject[] array, GameObject prefab)
	{
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Instantiate(prefab, transform);
			array[i].SetActive(false);
		}
	}

	public GameObject GetPooledObject(string name)
	{
		if (name == "trap")
		{
			for (int i = 0; i < _traps.Length; i++)
			{
				if (!_traps[i].activeSelf) return _traps[i];
			}
			return null;
		}
		else if (name == "tunnel")
		{
			for (int i = 0; i < _tunnels.Length; i++)
			{
				if (!_tunnels[i].activeSelf) return _tunnels[i];
			}
			return null;
		}
		else if (name == "insect")
		{
			for (int i = 0; i < _insects.Length; i++)
			{
				if (!_insects[i].activeSelf) return _insects[i];
			}
		}
		return null;
	}

	private void Move(GameObject[] array)
	{
		foreach (GameObject obj in array)
		{
			obj.transform.Translate(Vector3.left * speed * Time.deltaTime);
			if (obj.transform.position.z <= -140f) obj.SetActive(false);
		}
	}
}