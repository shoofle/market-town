using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	// ??
	void OnGUI ()
	{
		GameObject go = GameObject.Find("DirectionalLight");
		DirectDay light = go.GetComponent<DirectDay>();

		float t = light.currentTime;
		string hour = LeadingZero ((int) Math.Floor(t));
		string minute = LeadingZero ((int) ((t - Math.Floor (t)) * 60));

		GUILayout.Label(hour +":"+ minute);
	}

	// Adds Zeros to number if needed
	private string LeadingZero(int n){
		return n.ToString().PadLeft(2, '0');
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
