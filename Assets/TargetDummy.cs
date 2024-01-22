using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDummy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Animator dummyAnimator;
    private void OnCollisionEnter(Collision collision)
    {
     if (collision.gameObject.CompareTag("Weapon") )
        {
            dummyAnimator.SetTrigger("Death");
        }   
    }
     public void ActivateDummy()
    {
        dummyAnimator.SetTrigger("Activate");
    }
}
