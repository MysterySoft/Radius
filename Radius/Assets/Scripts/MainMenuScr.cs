using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScr : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void About(GameObject panel)
	{
        if (panel.active == true)
            panel.active = false;
        else
            panel.active = true;

    }

    public void CloseApp()
	{
		Application.Quit();
	}

	public void StartGame()
	{
		SceneManager.LoadScene (1);
	}
	// Update is called once per frame
	void Update () {
	
	}
}
