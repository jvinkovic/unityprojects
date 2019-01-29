using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {


    private Paddle paddle;

    private bool hasStarted = false;
    private Vector3 paddleToBallVector;

    // Use this for initialization
    void Start () {
        paddle = GameObject.FindObjectOfType<Paddle>();

        paddleToBallVector = this.transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update() {
        if (!hasStarted)
        {
            this.transform.position = paddle.transform.position + paddleToBallVector;

            if (Input.GetMouseButtonDown(0))
            {
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2, 10);
                hasStarted = true;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Vector2 tweak = new Vector2(Random.Range(0f,0.8f), Random.Range(0f, 0.8f));

        
        // if it is collided with object that has script Brick attached then do not play sound (boing)
        if (hasStarted && !collision.gameObject.GetComponent<Brick>())
        {
            GetComponent<AudioSource>().Play();
        }

        this.GetComponent<Rigidbody2D>().velocity += tweak;
    }
}
