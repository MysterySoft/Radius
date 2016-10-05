using UnityEngine;
using System.Collections;

public class SelfDestroy : MonoBehaviour {

	public float time;
	// Use this for initialization
	void Start () {
		StartCoroutine(DestroySelf ());
	
	}
	IEnumerator DestroySelf() {
		yield return new WaitForSeconds(time);
		Destroy (transform.gameObject);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
