using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator dummyAnimator;
	[SerializeField] private float padding;
	[SerializeField] private int scoreOnHit;
	[SerializeField] private AudioClip hitSoundEffect;
	private int hitCount = 0;

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") )
        {
			if (dummyAnimator != null)
			{
				dummyAnimator.SetTrigger("Death");
			}
			CalculateRicochetBonus(collision);
			AudioSource.PlayClipAtPoint(hitSoundEffect, this.transform.position);
			DisplayScoreText();

			hitCount++;
			if (hitCount == 4)
			{
				Destroy(this.gameObject);
			}
		}
    }


	private void CalculateRicochetBonus(Collision collision)
	{
		Ricochet bullet = collision.gameObject.GetComponent<Ricochet>();
		this.scoreOnHit = this.scoreOnHit * (bullet.collisionCount);
	}

	private void DisplayScoreText()
	{
        ScoreManager.Instance.scorePrefabText.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + padding, this.transform.position.z);
        ScoreManager.Instance.scorePrefabText.gameObject.SetActive(true);
        ScoreManager.Instance.IncreaseScore(scoreOnHit);
        StartCoroutine(DeactivatePointNumber());
	}
	private void OnEnable()
	{
		StopCoroutine(DeactivatePointNumber());
	}

	public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }

    IEnumerator DeactivatePointNumber()
	{
		yield return new WaitForSeconds(1f);
		ScoreManager.Instance.scorePrefabText.gameObject.SetActive(false);
	}
}
