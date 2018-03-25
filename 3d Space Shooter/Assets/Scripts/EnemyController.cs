using UnityEngine;
 using UnityEngine.UI;


public class EnemyController : MonoBehaviour
{
	// public GameObject enemy;
	public Transform Player;
	public float Max;
	public float Min;
	public float MoveSpeed;

	//Shooting variables
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;

	private AudioSource audioSource;
	private float dist;
	private float nextFire;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
	}

	void Update()
	{
		//Distance from player
		dist = Vector3.Distance(Player.position, transform.position);
		Debug.Log (dist);

		if(dist <= Max)
		{
			transform.LookAt(Player);
			
			// Debug.Log(transform.forward);
			if (transform.forward == new Vector3(0,0,0))
			{
				transform.forward = new Vector3(0, 0, 1);

			}

			transform.position += transform.forward*MoveSpeed*Time.deltaTime;

			if (Time.time > nextFire) 
			{
				nextFire = Time.time + fireRate;
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
				audioSource.Play();
			}

			if(dist <= Min)
			{
				return;
			}							
		}			
	}
}