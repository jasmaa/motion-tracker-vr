using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TimeFrame {
	public float time;
	public Vector3 rPosition;
	public Vector3 lPosition;

	public TimeFrame(float t, Vector3 rp, Vector3 lp){
		time = t;
		rPosition = rp;
		lPosition = lp;
	}
}
