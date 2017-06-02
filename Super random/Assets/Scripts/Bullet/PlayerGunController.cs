using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GunProperty
{
	public Transform player;                    // Player's transform
	public BulletMode bulletMode;               // Mode of bullets, might be NORMAL or CHAOS
	public int bulletLevel;                     // Level of bullet
	public float gunSpeed;                      // Speed of moving gun
	public Offset verticalOffset;               // Vertical moving offset
	public Offset horizontalOffset;             // Horizontal moving offset
	public Vector3 startOffset;                 // Offset from start
}


public class PlayerGunController : MonoBehaviour {

	// List of guns in gun controller
	public List<GunProperty> guns;	

	public virtual void SetupGuns()
	{
		foreach (GunProperty gp in guns)
		{
			
		}
	}
}
