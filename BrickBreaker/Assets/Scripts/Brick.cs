using UnityEngine;
using System.Collections;
using System;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public GameObject smoke;
    public static int breakableCount = 0;

    public Sprite[] hitSprites;

    private int timesHit;
    private bool isBreakable;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {

        isBreakable = this.tag == "Breakable";

        if (isBreakable)
        {
            breakableCount++;
        }

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        timesHit = 0;
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        AudioSource.PlayClipAtPoint(crack, transform.position);
         
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;

        int maxHits = hitSprites.Length + 1;

        if (timesHit >= maxHits)
        {

            breakableCount--;
            GameObject smokeInstance = Instantiate(smoke, gameObject.transform.position, Quaternion.identity) as GameObject;
            smokeInstance.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;

            Destroy(gameObject);

            levelManager.BrickDestroyed();
        }
        else
        {
            LoadSprites();
        }
    }

   

    private void LoadSprites()
    {
        int index = timesHit -1;

        if (hitSprites[index] != null)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[index];
        }
        else
        {
            Debug.LogError("No brick sprite on index " + index );
        }
    }
}
