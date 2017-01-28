using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public float defaultValueEffectZoonOut = 8;
    public float defaultValueEffectZoonIn = 3;
    private float defaultZoonDistance;
    public float speedTransitionCam = 15;

    // Use this for initialization
    void Start()
    {
        if (!Camera.main.orthographic)
        {
            Debug.LogError("Set Main Camera projection orthographic");
        }
        defaultZoonDistance = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Camera Actions and effects
    public void zoonOut()
    {
        StartCoroutine(coreZoon(defaultValueEffectZoonOut));
    }

    public void zoonOut(int valueDistance)
    {
        StartCoroutine(coreZoon(valueDistance));
    }

    public void zoonIn()
    {
        StartCoroutine(coreZoon(defaultValueEffectZoonIn, true));
    }

    public void zoonIn(int valueDistance)
    {
        StartCoroutine(coreZoon(valueDistance, true));
    }

    public void returnDefaultZoon()
    {
        if (Camera.main.fieldOfView < defaultZoonDistance)
        {
            StartCoroutine(coreZoon(defaultZoonDistance));
        }
        else if (Camera.main.fieldOfView > defaultZoonDistance)
        {
            StartCoroutine(coreZoon(defaultZoonDistance, true));
        }
    }

    private IEnumerator coreZoon(float valueDistance, bool zoonIn = false)
    {
        while (!zoonIn && Camera.main.orthographicSize < valueDistance)
        {
            Camera.main.orthographicSize += speedTransitionCam * Time.deltaTime;
            yield return null;
        }
        while (zoonIn && Camera.main.orthographicSize > valueDistance)
        {
            Camera.main.orthographicSize -= speedTransitionCam * Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(1f);
    }

    #endregion
}
