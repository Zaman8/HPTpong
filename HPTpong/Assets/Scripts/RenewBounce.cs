using UnityEngine;
using System.Collections;

public class RenewBounce : MonoBehaviour {
    Rigidbody2D rb;
    public GameObject p2;
    PaddleController p2PC;
    Vector2 pastV;
    Vector2 pastV2;
    [SerializeField]
    int timeAdjust;
    public float restartTime;
    float speedIncrease;
    // Use this for initialization
    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        p2PC = p2.GetComponent<PaddleController>();
        StartCoroutine("velocity");
        speedIncrease = 0;
    }

    void FixedUpdate() {
        speedIncrease = (speedIncrease > 5000) ? 5000 : ((Time.timeSinceLevelLoad - restartTime) / timeAdjust) + 500;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        p2PC.determineAttack = true;
        p2PC.secondPosition = this.gameObject.transform.position;
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) {
            float yvalue = 350 * (this.gameObject.transform.position.y - collision.gameObject.transform.position.y);
            Vector2 add = (collision.gameObject.CompareTag("Player1")) ? new Vector2(-1 * speedIncrease, yvalue) : new Vector2(speedIncrease, yvalue);
            rb.AddForce(add);
        } else if (collision.gameObject.CompareTag("Horizontal wall")) {
            int addY = (this.gameObject.transform.position.y > 0) ? -100 : 100;
            float addX = (rb.velocity.x > 0) ? speedIncrease : -1 * speedIncrease;
            addX = addX / 10;
            Vector2 add = new Vector2(addX, -3 * pastV.y + addY);
            rb.AddForce(add);
        }
    }
    IEnumerator velocity() {
        pastV = rb.velocity;
        yield return new WaitForSeconds(0.5f);
        //pastV2 = rb.velocity;
        //yield return new WaitForSeconds(0.5f);
    }
}
