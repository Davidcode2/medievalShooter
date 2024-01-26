using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MovementAudio : MonoBehaviour
{
	[SerializeField] private AudioClip[] footstepSounds;
	[SerializeField] private GameObject characterPrefab;

	private float minStepInterval = 0.5f;
	private float maxStepInterval = 1.5f;
	private float nextStepTime;

	private Vector3 lastSavedPosition;

	private void Start()
	{
		lastSavedPosition = characterPrefab.transform.position;
	}

	void Update()
	{
		if (Vector3.Distance(lastSavedPosition, characterPrefab.transform.position) > 0.1f)
		{
			PlayRandomFootstepSound();
			lastSavedPosition = characterPrefab.transform.position;
		}
	}

	void PlayRandomFootstepSound()
	{
		if (Time.time > nextStepTime)
		{
			if (footstepSounds.Length > 0)
			{
				int randomIndex = Random.Range(0, footstepSounds.Length);
				AudioSource.PlayClipAtPoint(footstepSounds[randomIndex], characterPrefab.transform.position);

				nextStepTime = Time.time + Random.Range(minStepInterval, maxStepInterval);
			}
		}
	}
}
