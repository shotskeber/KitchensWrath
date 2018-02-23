using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	public static gameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	public bool isPlaying = false;
	public float pointsToWin = 50;

	public float p1Points = 0;
	public float p2Points = 0;
	public float p3Points = 0;
	public float p4Points = 0;

	public float winner;

	public bool gameOver = false;

	public bool p1Active = false;
	public bool p2Active = false;
	public bool p3Active = false;
	public bool p4Active = false;

	public float windDiff = 0f;
	public float fireDiff = 0f;
	public float meatDiff = 0f;
    
    public float p1skin = 1;
    public float p2skin = 2;
    public float p3skin = 3;
    public float p4skin = 4;

    public float rounds = 0;

    //Awake is always called before any Start functions

    public void Start()
    {
        p1skin = 1;
        p2skin = 2;
        p3skin = 3;
        p4skin = 4;
    }
    void Awake()
	{
		//Check if instance already exists
		if (instance == null) {
			//if not, set instance to this
			instance = this;
			//If instance already exists and it's not this:
		} else if (instance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

	}

	//Update is called every frame.
	void Update()
	{
		if (isPlaying) {
			if (p1Points >= pointsToWin) {
				gameOver = true;
				winner = 1;
				isPlaying = false;
			}else if (p2Points >= pointsToWin) {
				gameOver = true;
				winner = 2;
				isPlaying = false;
			}else if (p3Points >= pointsToWin) {
				gameOver = true;
				winner = 3;
				isPlaying = false;
			}else if (p4Points >= pointsToWin) {
				gameOver = true;
				winner = 4;
				isPlaying = false;
			}
		}
	}
}