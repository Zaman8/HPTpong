using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool isAI;
    public bool isHard;
    public int max;

    // Use this for initialization
    void Start() {
        Application.runInBackground = false;
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
        Object.DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Single Player");
    }

    void OnLevelWasLoaded(int level) {
        if (level == 1) {

        }
    }
}
