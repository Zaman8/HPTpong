using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderText : MonoBehaviour {
    Text text;
    Slider slider;

	// Use this for initialization
	void Start () {
        slider = this.gameObject.GetComponentInParent<Slider>();
        text = this.gameObject.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        text.text = string.Format("Game To: {0}", slider.value);
	}
}