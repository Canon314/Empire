using UnityEngine;
[System.Serializable]
public class Saver
{
    public string armies;
    public float r, g, b, a;
    public Saver(ColorHandler handler)
    {
        armies = handler.armyText.text;
        Color color = handler.CurrentColor;
        r = color.r;
        g = color.g;
        b = color.b;
        a = color.a;
    }
    public Color GetColor()
    {
        return new Color(r, g, b, a);
    }

    public string text;

    public Saver(ButtonTextHandler buttonHandler)
    {
        text = buttonHandler.buttonText.text;
    }
}