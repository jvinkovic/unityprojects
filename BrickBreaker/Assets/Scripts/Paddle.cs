using UnityEngine;
using System.Collections;
using System;

public class Paddle : MonoBehaviour {

    public bool autoplay = false;
    private Ball ball;

    // Use this for initialization
    void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
    }
    
    // Update is called once per frame
    void Update () {
        if (!autoplay)
        {
            MoveWithMouse();
        }
        else
        {
            Autoplay();
        }
    }

    private void Autoplay()
    {
        Vector3 paddlePos = new Vector3(Mathf.Clamp(ball.transform.position.x, 0.7f, 15.3f), this.transform.position.y);
        transform.position = paddlePos;
    }

    void MoveWithMouse()
    {
        float mousePos = Input.mousePosition.x / Screen.width * 16;

        Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePos, 0.5f, 15.5f), this.transform.position.y);

        transform.position = paddlePos;
    }
}
