using UnityEngine;
using System.Collections;

public class wallglowe : MonoBehaviour {

	public Color a, b, c;
	public GameObject wall;
	public MeshRenderer mesh;

	// Use this for initialization
	void Start () {
		mesh = GetComponent<MeshRenderer>();

		//c = GetComponent<MeshRenderer> ().material.color;

	}
	
	// Update is called once per frame
	void Update () {
		mesh.material.color = Color.Lerp (a, b, Mathf.PingPong (Time.time, 1));
	}
}
