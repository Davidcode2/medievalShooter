using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] TargetDummies;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            foreach(GameObject dummies in TargetDummies) {
                dummies.GetComponent<TargetDummy>().ActivateDummy();
            }
        }
    }


}
