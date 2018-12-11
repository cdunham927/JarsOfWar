using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeText : MonoBehaviour {
    public float val;
    Text text;
    public string strText;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void OnEnable () {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        text.text = strText;
	}
	
	// Update is called once per frame
	void Update ()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - val);
    }

    public void ChangeText()
    {
        if (text.text == "") text.text = strText;
        else text.text = "";
    }
}
