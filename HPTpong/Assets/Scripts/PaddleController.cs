using UnityEngine;
using System.Collections;
using System.Timers;

public class PaddleController : MonoBehaviour {
    public bool isAi;
    Rigidbody2D ballRd;
    public GameObject ball;
    [SerializeField]
    float speed;
    Vector3 firstPosition;
    Vector3 secondPosition;
    // Use this for initialization
    void Start() {
        ballRd = ball.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (this.gameObject.CompareTag("Player1")) {
            float input = Input.GetAxisRaw("Vertical");
            transform.Translate(new Vector3(0, input * speed, 0));
        } else if (this.gameObject.CompareTag("Player2")) {
            float input = (isAi) ? ComputerMove() : Input.GetAxisRaw("Horizontal");
            transform.transform.Translate(new Vector3(0, input * speed, 0));
        }
        if (transform.position.y > 4.75 || transform.position.y < -4.75) {
            float newY = (transform.position.y > 4.75) ? 4.75f : -4.75f;
            transform.position = new Vector3(transform.position.x, newY, 0);
        }
    }

    float ComputerMove() {
        firstPosition = ball.transform.position;
        Debug.Log("First: " + firstPosition + "Second: " + secondPosition);
        if (firstPosition.x < secondPosition.x) {
            float m = ((firstPosition.y - secondPosition.y) / (firstPosition.x - secondPosition.x));
            Debug.Log("m:" + m);
            double y = m * (-10.5 - secondPosition.x) + secondPosition.y;
            if (y > transform.position.y-0.5 && y < transform.position.y +0.5 ) {
                return 0;
            }
            else if (y < transform.position.y)
                return -1;
            else if (y > transform.position.y)
                return 1;
        }
        return 0;
    }
}
