using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public float fireSpeed = 20;
    public GameObject muzzleFlashParticles;

    // Start is called before the first frame update
    void Start()
    {
        XRGrabInteractable grabbable = GetComponent<XRGrabInteractable>();
        grabbable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FireBullet(ActivateEventArgs arg)
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = spawnPoint.position;
        spawnedBullet.GetComponent<Rigidbody>().velocity = spawnPoint.forward * fireSpeed;
        Destroy(spawnedBullet, 5);

        if (muzzleFlashParticles != null)
        {
            GameObject muzzleFlash = Instantiate(muzzleFlashParticles, spawnPoint.position, spawnPoint.rotation);
            // Adjust the following line if the position is not aligned properly
            muzzleFlash.transform.parent = spawnPoint; // Make the muzzle flash a child of the spawn point
            Destroy(muzzleFlash, 1.0f); // Destroy the muzzle flash after 1 second (or adjust as needed)
        }
    }
}
