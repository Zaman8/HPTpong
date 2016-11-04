using UnityEngine;
using System.Collections;

public class BallStart : MonoBehaviour {
    public GameObject ball;
    Rigidbody2D ballRd;
    RenewBounce renewBounce;
    int a, b;
    // Use this for initialization
    void Start() {
        ballRd = ball.GetComponent<Rigidbody2D>();
        StartCoroutine("start");
        renewBounce = ball.gameObject.GetComponent<RenewBounce>();
    }
    public void starting() {
        StartCoroutine("start");
    }
    public void restart(int a) {
        ball.gameObject.transform.position = new Vector3(0, 0, 0);
        this.a = a;
        StartCoroutine("restartC");
    }
    IEnumerator start() {
        int xvalue = (Random.Range(1, 2) == 1) ? -500 : 500;
        ballRd.velocity = new Vector2(0, 0);
        ball.transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(3);
        renewBounce.restartTime = Time.timeSinceLevelLoad;
        ballRd.AddForce(new Vector2( xvalue,0));
    }
    IEnumerator restartC() {
        yield return new WaitForSeconds(3);
        ballRd.AddForce(new Vector2(a, 0));
        renewBounce.restartTime = Time.timeSinceLevelLoad;
        yield break;
    }
}