using Assets.ECS.Data;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
	public static Action GameOver;

	[SerializeField]
	StaticData _staticData;

	[SerializeField]
	GameObject Score;
	[SerializeField]
	GameObject Explosion;
	[SerializeField]
	GameObject GameOverText;

	float distance = 0;

	public void StartExplosion()
	{
		Explosion.SetActive(true);
		GameOverText.SetActive(true);
		Explosion.GetComponent<Animator>().SetBool("explosion", true);
	}
	void Start()
	{
		Explosion.SetActive(false);
		GameOverText.SetActive(false);
		StartCoroutine(ScoreTimer());
		GameOver += StartExplosion;
	}
	IEnumerator ScoreTimer()
	{
		distance++;
		Score.GetComponent<TMP_Text>().text = $"{distance} M";
		Score.GetComponent<Animator>().SetBool("pop", true);
		yield return new WaitForSeconds(1f / (_staticData.PlayerSpeed / 40f));
		Score.GetComponent<Animator>().SetBool("pop", false);
		if (!_staticData.IsGameOver)
		{
			StartCoroutine(ScoreTimer());
		}
	}
	void Update()
	{
	}

}
