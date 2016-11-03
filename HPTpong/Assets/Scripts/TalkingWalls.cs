using UnityEngine;
using System.Collections;

public class TalkingWalls : MonoBehaviour {
    Scores scores;
    BallStart ballStart;
    public GameObject sceneManager;
    public GameObject ball;
    [SerializeField]
    int player;
    int a;
    // Use this for initialization
    void Start() {
        scores = sceneManager.GetComponent<Scores>();
        ballStart = sceneManager.GetComponent<BallStart>();
        a = (player == 1) ? 500 : -500;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.CompareTag("ball")) {
            scores.addScore(3-player);
            ballStart.restart(a);
        }
    }
}
