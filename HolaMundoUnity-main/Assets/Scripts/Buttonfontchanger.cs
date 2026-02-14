using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Buttonfontchanger : MonoBehaviour
{
    public Button button;
    public Color color1 = Color.white;
    public Color color2 = Color.blue;

    private TextMeshProUGUI buttonText;
    private bool toggle = false;

    void Start()
    {
        if (button != null)
        {
            buttonText = button.GetComponentInChildren<TextMeshProUGUI>();
            button.onClick.AddListener(ChangeColor);
        }
    }

    void ChangeColor()
    {
        if (buttonText != null)
        {
            toggle = !toggle;
            buttonText.color = toggle ? color2 : color1;
        }
    }
}
