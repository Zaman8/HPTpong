using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreDisplay : MonoBehaviour {
    Text score;
	// Use this for initialization
	void Start () {
        score = gameObject.GetComponent<Text>();
	}
	
    public void refresh(int player1one, int player2one) {
        score.text = string.Format("{0} : {1}", player2one, player1one);
    }
}
