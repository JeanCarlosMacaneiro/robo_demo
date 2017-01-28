using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggerCameraEffects : MonoBehaviour {

    public bool effectZooIn;
    public bool effectZoonout;
    public bool returnDefaultZoon;

	// Use this for initialization
	void Start ()
    {
        this.GetComponent<BoxCollider2D>().isTrigger = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            DestroyObject(this.gameObject);
            if (effectZoonout)
            {
                Camera.main.GetComponent<CameraController>().zoonOut();
            }
            else if (effectZooIn)
            {
                Camera.main.GetComponent<CameraController>().zoonIn();
            }
            else if (returnDefaultZoon)
            {
                Camera.main.GetComponent<CameraController>().returnDefaultZoon();
            }
        }
    }
}
