using UnityEngine;
using System.Collections;

public class CollectibleItem : MonoBehaviour {

    public int pointsScores = 100;

    private GameObject canvas;

	// Use this for initialization
	void Start () {
	    canvas = GameObject.Find("Canvas");
        this.gameObject.GetComponent<Collider2D>().isTrigger = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            canvas.GetComponent<CanvasController>().addScorepoints(pointsScores);
            DestroyObject(this.gameObject);
        }
    }

}
