using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour {

	public GameObject Player;
	public bool fail;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Player == null) 
		{
			fail = true;
		}
	}
}
