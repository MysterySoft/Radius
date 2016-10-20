using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour {

    int time = 1;
    public GameObject panel;
    public GameObject button;

    public void pause()
    {
        time = 0;
        panel.active = true;
        button.active = false;
    }

    public void resume()
    {
        panel.active = false;
        button.active = true;
        time = 1;
    }

    public void exit()
    {
        Application.Quit();
    }

    public void menu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(1);
    }

    void Start () {
	
	}
	
	void Update () {
        Time.timeScale = time;
	}
}
