using UnityEngine;
using System.Collections;

public class ButtonStartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startNewgame()
    {
        GameController.Instance.startGame();
    }
}
