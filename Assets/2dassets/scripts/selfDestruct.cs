﻿using UnityEngine;
using System.Collections;

public class SelfDestruct : MonoBehaviour {
	
	public float time;
	
	// Use this for initialization
	void Start () {
		Destroy (this.gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	
}