using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MotionTracker : MonoBehaviour {

	public Transform rHand;
	public Transform lHand;

	public DataContainer data;

	void Start(){
		data = new DataContainer ();
	}

	// Update is called once per frame
	void Update () {
		TimeFrame tf = new TimeFrame (Time.time, rHand.position, lHand.position) ;
		data.tracking.Add (tf);

		print (JsonUtility.ToJson(tf));
	}

	void OnDestroy(){
		using (StreamWriter writer = File.AppendText (System.String.Format("../data/out--{0}.json", System.DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss")))) {
			writer.WriteLine (JsonUtility.ToJson(data));
			writer.Close ();	
		}
		print ("Data written");
	}
}
