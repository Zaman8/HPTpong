using UnityEngine;
using System.Collections;

public class Scores : MonoBehaviour {
    public int player1Score;
    public int player2Score;
    public int max;
    public GameObject UI;
    ScoreDisplay display;
    PauseMenu pauseMenu;
    // Use this for initialization
    void Start() {
        player1Score = 0;
        player2Score = 0;
        display = UI.GetComponent<ScoreDisplay>();
        pauseMenu = this.GetComponent<PauseMenu>();
    }

    public void addScore(int player) {
        if (player == 1)
            player1Score += 1;
        if (player == 2)
            player2Score += 1;
        display.refresh(player1Score, player2Score);
        if (player1Score  >= max || player2Score >= max) {
            pauseMenu.pause();
        }
    }
}