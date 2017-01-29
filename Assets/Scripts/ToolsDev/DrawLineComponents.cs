using UnityEngine;
using System.Collections;

public class DrawLineComponents : MonoBehaviour
{
    public Color colorLine = Color.magenta;
    #region not Use
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    public void OnDrawGizmos()
    {
        
        Gizmos.color = colorLine;
        Vector2 p1 = new Vector2(this.transform.position.x + this.GetComponent<BoxCollider2D>().bounds.size.x / 2, this.transform.position.y + this.GetComponent<BoxCollider2D>().bounds.size.y / 2);
        Vector2 p2 = new Vector2(this.transform.position.x + this.GetComponent<BoxCollider2D>().bounds.size.x / 2, this.transform.position.y - this.GetComponent<BoxCollider2D>().bounds.size.y / 2);
        Vector2 p3 = new Vector2(this.transform.position.x - this.GetComponent<BoxCollider2D>().bounds.size.x / 2, this.transform.position.y - this.GetComponent<BoxCollider2D>().bounds.size.y / 2);
        Vector2 p4 = new Vector2(this.transform.position.x - this.GetComponent<BoxCollider2D>().bounds.size.x / 2, this.transform.position.y + this.GetComponent<BoxCollider2D>().bounds.size.y / 2);
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p4, p1);

    }

}
