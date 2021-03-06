﻿using UnityEngine;
using System.Collections;

public class ObjDestroyer : MonoBehaviour {
	
	public GameObject explosionPrefab;
	public AudioClip explosionSound;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Destructable")) {
			Instantiate(explosionPrefab, col.transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint(explosionSound , transform.position);
			Destroy (col.gameObject);
		} 
	}
}
