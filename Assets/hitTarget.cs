using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitTarget : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("shot");
        if (collision.gameObject.CompareTag("Weapon"))
        {
            Debug.Log("shot");
        }
    }

}
