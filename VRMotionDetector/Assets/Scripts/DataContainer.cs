using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataContainer {
	public List<TimeFrame> tracking;

	public DataContainer(){
		tracking = new List<TimeFrame> ();
	}
}
