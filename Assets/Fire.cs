using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private AudioClip fireSound;


    public void FireBullet()
    {
        GameObject spawnedBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * bulletSpeed;
        AudioSource.PlayClipAtPoint(fireSound, spawnPoint.position);
        if (spawnedBullet != null)
        {
			Destroy(spawnedBullet, 10f);
		}
    }
}
