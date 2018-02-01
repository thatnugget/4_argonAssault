using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class musicplayer : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
        DontDestroyOnLoad(this);

    }

    void Start () {
        Invoke("LoadFirstScene", 3f);
	}
	 
	// Update is called once per frame
	void Update () {
        
	}

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);

    }
}
