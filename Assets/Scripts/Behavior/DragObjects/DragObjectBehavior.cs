using UnityEngine;
using System.Collections;

public class DragObjectBehavior : MonoBehaviour
{
    private Vector3 handleToOriginVector;
    public bool inDragging;
    private LayerMask layerMask;

    // Use this for initialization
    void Start()
    {
        handleToOriginVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || UNITY_EDITOR_WIN || UNITY_WEBGL || UNITY_STANDALONE_WIN

        if (Input.GetButtonDown("Fire1"))
        {
            OnMouseDown();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            OnMouseUp();
        }

        if (inDragging)
        {
            OnMouseDrag();
        }
#endif
    }

    private void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, float.MaxValue, LayerMask.GetMask("DragAndDrop"));
        
        if (hit.collider != null)
        {
            if (hit.collider.tag.Equals("DragObject") && hit.collider.name.Equals(this.gameObject.name))
            {
                handleToOriginVector = hit.collider.gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                inDragging = true;
                this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            }
        }
    }

    private void OnMouseDrag()
    {
        this.gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + handleToOriginVector;
    }

    private void OnMouseUp()
    {
        inDragging = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}