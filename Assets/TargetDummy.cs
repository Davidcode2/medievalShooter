using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator dummyAnimator;
	[SerializeField] private float padding;
	[SerializeField] private int scoreOnHit;

	private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet") )
        {
			if (dummyAnimator != null)
			{
				dummyAnimator.SetTrigger("Death");
			}
			ScoreManager.Instance.scorePrefabText.gameObject.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + padding, this.transform.position.z);
			ScoreManager.Instance.scorePrefabText.gameObject.SetActive(true);
			ScoreManager.Instance.IncreaseScore(scoreOnHit);
            StartCoroutine(DeactivatePointNumber());
		}   
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
