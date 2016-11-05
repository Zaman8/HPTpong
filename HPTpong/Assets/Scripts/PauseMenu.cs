using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {
    bool ispaused;
    Scores score;
    public GameObject menu;
    BallStart starting;
    // Use this for initialization
    void Start() {
        ispaused = false;
        score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scores>();
        starting = this.GetComponent<BallStart>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (ispaused) {
                ispaused = false;
                menu.SetActive(false);
                Time.timeScale = 1;
            } else {
                ispaused = true;
                menu.SetActive(true);
                Time.timeScale = 0;
            }             
        }
    }


    public void restart() {
        score.player1Score = 0;
        score.player2Score = 0;
        menu.gameObject.SetActive(false);
        ispaused = false;
        Time.timeScale = 1;
        starting.starting();
    }
    public void exit() {
        Application.Quit();
    }
}
