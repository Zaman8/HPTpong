using UnityEngine;
using System.Collections;

public class BallStart : MonoBehaviour {
    public GameObject ball;
    Rigidbody2D ballRd;
    int a, b;
    // Use this for initialization
    void Start() {
        ballRd = ball.GetComponent<Rigidbody2D>();
        StartCoroutine("start");
    }
    public void restart(int a, int b) {
        ball.gameObject.transform.position = new Vector3(0, 0, 0);
        this.a = a;
        this.b = b;
        StartCoroutine("restartC");
    }
    IEnumerator start() {
        yield return new WaitForSeconds(3);
        ballRd.AddForce(new Vector2(Random.Range(-200, 200), Random.Range(-100, 100)));
    }
    IEnumerator restartC() {
        yield return new WaitForSeconds(3);
        ballRd.AddForce(new Vector2(Random.Range(a, b), Random.Range(-100, 100)));
    }
}
