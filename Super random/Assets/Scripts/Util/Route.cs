using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour {

	public Spline spline;					// gameOjbect move along this spline
	public int breakNodeNumber;				// Node's id in spline, to break
	public float timeBreak;                 // Time break when gameObject reach break node
	protected float breakNodePosition;      // Normalized position in spline
	protected float passedTimeBreak;		// Time passed since start


	protected virtual void Start()
	{
		// If breakNodeNumber is not valid
		if (breakNodeNumber > spline.splineNodes.Length - 1 || breakNodeNumber < 0)
		{
			breakNodeNumber = -1;
			breakNodePosition = 0;
			timeBreak = 0;
		}		
	}


	protected virtual void FixedUpdate()
	{
		// If breakNodeNumber valid
		if (breakNodeNumber != -1)
		{
		}
	}
}
