using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderGameTo : MonoBehaviour {
    Slider slider;
    // Use this for initialization
    void Start() {
        slider = this.gameObject.GetComponent<Slider>();
        slider.wholeNumbers = true;
    }

    // Update is called once per frame
    void Update() {

    }

}
