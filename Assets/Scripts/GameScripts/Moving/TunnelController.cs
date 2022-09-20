using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelController : MonoBehaviour
{
	[SerializeField]
	private Difficulty diff;

	[SerializeField]
	private Pool pool;

	[SerializeField]
	private Transform respawn;

	[SerializeField]
	private float distance = 150f;

	private float between;

	private GameObject currentTunnel;

	[SerializeField]
	private Transform lastTunnel;


	private void Start()
	{
		currentTunnel = lastTunnel.gameObject;
	}
	private void LateUpdate()
	{

		if (between > distance)
		{
			Create();
		}
		else
		{
			lastTunnel = currentTunnel.transform;
			between = respawn.position.z - lastTunnel.position.z;
		}
	}


	private void Create()
	{
		currentTunnel = pool.GetPooledObject("tunnel");
		if (currentTunnel != null)
		{
			currentTunnel.transform.position = lastTunnel.position + Vector3.forward * 150f;
			currentTunnel.SetActive(true);
			lastTunnel = currentTunnel.transform;
			between = respawn.position.z - lastTunnel.position.z;
		}

	}
}
