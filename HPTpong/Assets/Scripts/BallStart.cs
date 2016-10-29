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
        int xvalue = (Random.Range(1, 2) == 1) ? Random.Range(-500, -250) : Random.Range(250, 500);
        yield return new WaitForSeconds(3);
        ballRd.AddForce(new Vector2( xvalue, Random.Range(-50, 50)));
    }
    IEnumerator restartC() {
        yield return new WaitForSeconds(3);
        ballRd.AddForce(new Vector2(Random.Range(a, b), Random.Range(-100, 100)));
    }
}
