using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]   // Group's information store here
public class GroupProperty
{
	// All's var here refer to enemy group
	public GameObject enemyGroup;
	public GameObject spline;
	public float speed;
	public WrapMode wrapMode;
	public Vector3 splineOffset;
}


[System.Serializable]   // Wave's information, wave include many group
public class WaveProperty
{
	// Time to start, count since last wave
	public float timeStart;

	// List of group property
	public List<GroupProperty> groups;
}


public class WaveController : MonoBehaviour {

	public List<WaveProperty> waves;		// List of Wave property
	protected int waveIndex;				// current wave index of stage 
	protected float currentTime;			// current time since next wave


	// Spawn wave at index in waves list
	public virtual void SpawnWave(ref int waveIndex)
	{
		foreach (GroupProperty gp in waves[waveIndex].groups)
		{
			// Create group from prefab
			GameObject group = (GameObject)Instantiate(gp.enemyGroup, transform);

			// Move group out of screen to avoid showing onscreen at start
			group.transform.position = new Vector3(100, 100);

			// Create spline from prefab
			GameObject spline = (GameObject)Instantiate(gp.spline, transform);

			// Setup enemy group
			group.GetComponent<EnemyGroup>().Setup(spline.GetComponent<Spline>(), gp.speed, gp.splineOffset, gp.wrapMode);
		}

		// After spawn wave then reset currentTime
		currentTime = 0f;

		// And move to next wave
		waveIndex++;
	}


	// Used for accuracy
	public virtual void FixedUpdate()
	{
		// If out of wave in waves-list
		if (waveIndex > waves.Count - 1)
		{
			// Then do nothing
			return;
		}

		// currentTime always add up
		currentTime += Time.fixedDeltaTime;

		// If current time reach wave's timeStart
		if (currentTime >= waves[waveIndex].timeStart)
		{
			// Then spawn that wave
			SpawnWave(ref waveIndex);
		}
	}
}
