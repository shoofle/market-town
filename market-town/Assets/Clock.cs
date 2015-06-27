using UnityEngine;
using System.Collections;
using System;

public class Clock : MonoBehaviour {

	// ??
	void OnGUI ()
	{
		DateTime time = DateTime.Now;
		GameObject go = GameObject.Find("DirectionalLight");
		DirectDay light = go.GetComponent<DirectDay>();

		string hour = LeadingZero (light.HourOfDay);
		string minute = LeadingZero (light.MinutesOfHour);

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
