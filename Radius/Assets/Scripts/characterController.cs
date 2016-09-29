using UnityEngine;
using System.Collections;
using System;

public class characterController : MonoBehaviour {
	public GameObject player;
	public float speed;
	public float scale;
	public Texture []scins;
	public MeshRenderer mesh;

	void Start () {
		mesh = GetComponent<MeshRenderer> ();
		System.Random n = new System.Random ();
		int r = n.Next(0,7);
		mesh.material.mainTexture = scins [r];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	// Трігер на знищення хавки і збільшення розмірів іграка
	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "food") {
			Destroy (col.gameObject);
			transform.localScale += new Vector3 (scale, scale, scale);
		}
	}

	void Update(){
		player.transform.Translate (new Vector3 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"), 0)*Time.deltaTime*speed);
	}
}
