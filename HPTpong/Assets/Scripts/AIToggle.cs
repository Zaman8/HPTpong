using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AIToggle : MonoBehaviour {
    public GameObject hardToggle;
    Toggle otherToggle;
    Toggle toggle;
    // Use this for initialization
    void Start() {
        toggle = this.gameObject.GetComponent<Toggle>();
        otherToggle = hardToggle.GetComponent<Toggle>();
    }
	
	// Update is called once per frame
	void Update () {
        hardToggle.SetActive(toggle.isOn);
        otherToggle.isOn = (toggle.isOn == false) ? false : otherToggle.isOn;
	}
}
