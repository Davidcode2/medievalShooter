using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricochet : MonoBehaviour
{
    // Start is called before the first frame update
    public int collisionCount { get; set; }
    void Start()
    {
        this.collisionCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        collisionCount++;
    }
}
