using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class CameraFollow : MonoBehaviour
{
    public MonoBehaviour follower;

    private float positionXFollower;
    private float positionYFollower;

    // Use this for initialization
    void Start()
    {
        if (follower == null)
        {
            Debug.LogError("Set follower in script 'CameraFolow' ");
        }
    }

    // Update is called once per frame
    void Update()
    {
        positionXFollower = follower.transform.position.x;
        Vector3 newPosition = new Vector3(positionXFollower, transform.position.y, transform.position.z);
        this.gameObject.transform.position = newPosition;
    }
}
