using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {
    bool ispaused;
    Scores score;
    public GameObject menu;
    BallStart starting;
    // Use this for initialization
    void Start() {
        ispaused = false;
        score = this.GetComponent<Scores>();
        starting = this.GetComponent<BallStart>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (ispaused) {
                unpause();
            } else {
                pause();
            }             
        }
    }


    public void restart() {
        score.player1Score = 0;
        score.player2Score = 0;
        menu.SetActive(false);
        ispaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void exit() {
        Application.Quit();
    }
    public void unpause() {
        ispaused = false;
        menu.SetActive(false);
        Time.timeScale = 1;
    }
    public void pause() {
        ispaused = true;
        menu.SetActive(true);
        Time.timeScale = 0;
    }
}
