using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class EnemyBirdBehavior : MonoBehaviour
{

    public ParticleSystem deadParticle;
    public List<GameObject> pathPoints;
    public float timeMoveBetweenPath = 2;
    public iTween.EaseType easeTypeItween;
    public int valueDamegeInflict = 50;

    private GameObject nextPointPath;
    private int indexPath;
    private bool goToNextPoint;
    private bool isDead = false;

    // Use this for initialization
    void Start()
    {
        getNextPathPoint();
        indexPath = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("DeadBird"))
        {
            DestroyObject(this.gameObject);
        }
    }

    private void checkDirection()
    {
        if (nextPointPath.transform.position.x < this.gameObject.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("inWalkLeft", true);
            this.gameObject.GetComponent<Animator>().SetBool("inWalkRight", false);
        }

        if (nextPointPath.transform.position.x > this.gameObject.transform.position.x)
        {
            this.gameObject.GetComponent<Animator>().SetBool("inWalkRight", true);
            this.gameObject.GetComponent<Animator>().SetBool("inWalkLeft", false);
        }

        movement();
    }

    private void movement()
    {
        if (!isDead)
        {
            iTween.MoveTo(this.gameObject, iTween.Hash(
            "position", nextPointPath.transform.position,
            "time", timeMoveBetweenPath,
            "oncomplete", "getNextPathPoint",
            "easeType", easeTypeItween
            ));
        }
    }

    private void getNextPathPoint()
    {
        if (pathPoints != null && pathPoints.Count > 0)
        {
            if ((pathPoints.Count - 1) >= indexPath)
            {
                nextPointPath = pathPoints[indexPath];
            }
            else
            {
                indexPath = 0;
                nextPointPath = pathPoints[indexPath];
            }

            indexPath++;
        }
        else
        {
            nextPointPath = this.gameObject;
        }

        checkDirection();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            GameObject.Find("Canvas").GetComponent<CanvasController>().setDamege(valueDamegeInflict);
            this.gameObject.GetComponent<CircleCollider2D>().enabled = false;
            this.gameObject.GetComponent<Animator>().SetBool("birdIsDead", true);
            deadParticle.Play();
            isDead = true;
        }
    }
}
