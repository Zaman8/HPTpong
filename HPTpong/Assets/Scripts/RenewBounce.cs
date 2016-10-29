using UnityEngine;
using System.Collections;

public class RenewBounce : MonoBehaviour {
    Rigidbody2D rb;
    Vector2 pastV;
    // Use this for initialization
    void Start() {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        StartCoroutine("velocity");
    }

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision);
        if(collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2")) {
            float yvalue = 350 * (this.gameObject.transform.position.y - collision.gameObject.transform.position.y);
            Vector2 add = (collision.gameObject.CompareTag("Player1")) ? new Vector2(-500, yvalue) : new Vector2(500, yvalue);
            rb.AddForce(add);
        }
        else if (collision.gameObject.CompareTag("Horizontal wall")) {
            Debug.Log("velocity: " + rb.velocity);
            int added = (this.gameObject.transform.position.y > 0) ? -100 : 100;
            Vector2 add = new Vector2(rb.velocity.x, -3 * pastV.y + added);
            rb.AddForce(add);
        }
    }
    IEnumerator velocity() {
        pastV = rb.velocity;
        yield return new WaitForSeconds(0.5f);
    }
}
