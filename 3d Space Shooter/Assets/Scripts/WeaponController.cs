using UnityEngine;
using System.Collections;
using System;

public class WeaponController : MonoBehaviour
{
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	public float delay;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	void Fire()
	{
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			audioSource.Play();
	}
}