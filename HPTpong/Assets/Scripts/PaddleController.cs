using UnityEngine;
using System.Collections;
using System.Timers;

public class PaddleController : MonoBehaviour {
    public bool isAi;
    public bool isHard;
    public bool determineAttack = true;
    Rigidbody2D ballRd;
    public GameObject ball;
    public GameObject player1;
    [SerializeField]
    float speed;
    public Vector3 secondPosition;
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
        //Debug.Log("First: " + firstPosition + "Second: " + secondPosition);
        if (ball.transform.position.x < secondPosition.x) {
            double y = calBallMovement();
            if (!isHard) {
                return makeMove(y);
            }
            else {
                if (determineAttack) {
                    if (player1.transform.position.y > this.transform.position.y - 0.3 || player1.transform.position.y < this.transform.position.y + 0.3) {
                        if (Random.Range(1, 2) == 1)
                            y += 0.4;
                        else
                            y -= 0.4;
                    } else if (player1.transform.position.y > this.transform.position.y) {
                        y += 0.15;
                    } else if (player1.transform.position.y < this.transform.position.y) {
                        y -= 0.15;
                    }
                    determineAttack = false;
                }
                return makeMove(y);
            }
        }
        return 0;
    }
    double calBallMovement() {
        float m = ((ball.transform.position.y - secondPosition.y) / (ball.transform.position.x - secondPosition.x));
        double y = m * (-10.5 - secondPosition.x) + secondPosition.y;
        return y;
    }
    int makeMove(double y) {
        if (y > transform.position.y - 0.25 && y < transform.position.y + 0.25) 
            return 0;
         else if (y < transform.position.y)
            return -1;
        else if (y > transform.position.y)
            return 1;
        else
            return 0;
    }
}
