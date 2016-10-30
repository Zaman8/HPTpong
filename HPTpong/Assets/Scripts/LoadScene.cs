using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    public bool isAI;
    public bool isHard;
    public int max;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void loadSingle() {
        Application.runInBackground = false;
        Object.DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Single Player");
    }

    public void OnLevelWasLoaded(int level) {
        if (level == 1) {

        }
    }
}
