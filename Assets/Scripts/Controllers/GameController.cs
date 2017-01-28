using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour {

    /*<summary> 
       Time the version Trial is in seconds
   </summary> */
    public int timeTrial = 30;
    public bool isTrialVersion = true;
    

    /*<summary> 
       GameController Instance
   </summary> */
    public static GameController Instance
    {
        get
        {
            return instance;
        }
    }

    public PlayerController playerController
    {
        get {
            if (_playerController == null)
            {
                _playerController = new PlayerController();
            }
            return _playerController;
        }
    }

    internal bool endlevel;
    internal int actualLevel;

    private PlayerController _playerController;
    private static GameController instance = null;
   
    public enum ScenesNames
    {
        MenuGame,
        Level_1
    }

    private void Awake()
    {
        // if the singleton hasn't been initialized yet
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        endlevel = false;
        actualLevel = 1;
        _playerController = new PlayerController();
    }

    void Update()
    {
        
    }

    public void startGame()
    {
        Application.LoadLevel(ScenesNames.Level_1.ToString());
    }

    public void LoadScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public IEnumerator sleepThred(int timeSleep)
    {
        yield return new WaitForSeconds(timeSleep);
        StopCoroutine(sleepThred(timeSleep));
    }
}
