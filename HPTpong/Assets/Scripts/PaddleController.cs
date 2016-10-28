using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
    public bool isAi;
    public Rigidbody2D otherRb;
    public GameObject other;
    [SerializeField]
    float speed;
    // Use this for initialization
    void Start() {
        otherRb = other.GetComponent<Rigidbody2D>();
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
        Vector3 firstPosition = other.transform.position;
        Vector3 secondPosition = other.transform.position;
        if (firstPosition.x > secondPosition.x) {
            float m = (firstPosition.x - secondPosition.x) / (-1 * (firstPosition.y - secondPosition.y));
            double y = m * (-10.5 - secondPosition.x) + secondPosition.y;
            if (y < transform.position.y)
                return -1;
            else if (y > transform.position.y)
                return 1;
        }
        return 0;
    }
}
