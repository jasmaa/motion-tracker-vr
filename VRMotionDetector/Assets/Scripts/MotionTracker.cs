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
		string path = System.String.Format("../data/out--{0}.json", System.DateTime.Now.ToString ("yyyy-dd-M--HH-mm-ss"));
		using (StreamWriter writer = File.AppendText (path)) {
			writer.WriteLine (JsonUtility.ToJson(data));
			writer.Close ();

			print ("Data written to: " + Path.GetFullPath(path));
		}
	}
}
