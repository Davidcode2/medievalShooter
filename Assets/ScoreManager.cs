using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
	private static ScoreManager instance;
	public static ScoreManager Instance { get { return instance; } }

	private int score = 0;
	public TextMeshProUGUI scoreUI;
	public TextMeshPro scorePrefabText;
	public GameObject mainCamera;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(gameObject);
		}
	}

	void Start()
	{
		UpdateScoreUI();
	}

	// Increase the score by a given amount
	public void IncreaseScore(int amount)
	{
		scorePrefabText.text = "+" + amount.ToString();
		score += amount;
		UpdateScoreUI();
	}

	// Fetch the current score
	public int GetScore()
	{
		return score;
	}

	// Update the UI to display the current score
	private void UpdateScoreUI()
	{
		if (scoreUI != null)
		{
			scoreUI.text = "Score: " + score.ToString();
		}
	}

	private void Update()
	{
		if (scorePrefabText.gameObject.activeInHierarchy)
		{
			scorePrefabText.gameObject.transform.rotation = Quaternion.Euler(0f, mainCamera.transform.rotation.eulerAngles.y, 0f);
		}
	}
}
