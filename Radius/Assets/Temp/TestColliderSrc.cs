using UnityEngine;
using System.Collections;
[RequireComponent (typeof (Rigidbody))]
public class TestColliderSrc : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log ("Bingo!");
	}
	// Update is called once per frame
	void Update () {
	
	}
}
