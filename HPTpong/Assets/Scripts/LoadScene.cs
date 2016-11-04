using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    public bool isAI;
    public bool isHard;
    public int max;
    GameObject toggleAI;
    GameObject toggleHard;
    GameObject sliderGameTo;
    Toggle AI;
    Toggle Hard;
    Slider GameTo;
    PaddleController p2;
    Scores score;
    

    // Use this for initialization
    void Start() {
        Object.DontDestroyOnLoad(this.gameObject);
        Application.runInBackground = false;
        toggleAI = GameObject.Find("Play AI");
        AI = toggleAI.GetComponent<Toggle>();
        toggleHard = GameObject.Find("Hard");
        Hard = toggleHard.GetComponent<Toggle>();
        sliderGameTo = GameObject.Find("Game To");
        GameTo = sliderGameTo.GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update() {

    }
    public void setAI(bool value) {
        isAI = value;
    }
    public void setHard(bool value) {
        isHard = value;
    }
    public void setMax(int value) {
        max = value;
    }
    public void loadSingle() {
        isAI = AI.isOn;
        isHard = Hard.isOn;
        max = (int)GameTo.value;
        SceneManager.LoadScene("Single Player");
    }

    void OnLevelWasLoaded(int level) {
        if (level == 1) {
            p2 = GameObject.FindGameObjectWithTag("Player 2").GetComponent<PaddleController>();
            score = GameObject.FindGameObjectWithTag("GameController").GetComponent<Scores>();
            p2.isAi = isAI;
            p2.isHard = isHard;
            score.max = max;
        }
    }
}
