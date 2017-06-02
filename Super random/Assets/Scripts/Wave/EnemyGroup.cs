using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Group of enemy, use in wave
public class EnemyGroup : MonoBehaviour {
	
	public Spline spline;						// Spline that enemy group will fly along
	public float speed;                         // Speed of group when moving along route
	public WrapMode wrapMode;					// Wrap mode of route
	public Vector3 splineOffset;				// Spline's offset
	protected SplineAnimator splineAnimator;    // Allow gameObject move along route


	// Add Spline Animator, make gameObject move in spline 
	public virtual void AddSplineAnimator()
	{
		// If spline animator is not in gameObject 
		if ((splineAnimator = GetComponent<SplineAnimator>()) == null)
		{
			// Then add spline animator
			splineAnimator = gameObject.AddComponent<SplineAnimator>();
		}

		// Pass speed of enemy group to spline animator
		splineAnimator.speed = speed;

		// Pass spline to spline animator
		splineAnimator.spline = spline;

		// Pass wrap mode to spline animator
		splineAnimator.wrapMode = wrapMode;

		// Re-position spline
		SetPosition(splineOffset);
	}


	// Change position of spline by offset
	public virtual void SetPosition(Vector3 offset)
	{
		spline.transform.position += offset;
	}


	// Setup enemy group
	public virtual void Setup(Spline spline, float speed, Vector3 splineOffset, WrapMode wrapMode)
	{
		// Pass all parameters above to enemy group's variable
		this.spline = spline;
		this.speed = speed;
		this.splineOffset = splineOffset;
		this.wrapMode = wrapMode;

		// Now we have enough information to add spline animator
		AddSplineAnimator();
	}
}
