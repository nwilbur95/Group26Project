using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class EnemyStats: CharacterStats{

	public Stat fireRate;
	public Stat speed;
	public Stat engageRange;
	void Start()
	{
		fireRate.addModifier(1);
		speed.addModifier(1);
		engageRange.addModifier(1);
	}
}