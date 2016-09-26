using UnityEngine;
using System.Collections;

public class newcam : MonoBehaviour {
	public GameObject cam,pl;

	// Update is called once per frame
	void Start () {
		
	}
	void Update () 
	{
		cam.transform.position = pl.transform.position-new Vector3 (0,0,3);

	
	}
}
