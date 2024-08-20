using System;
using UnityEngine;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour
{
    private Image blackScreen;

    [SerializeField] private float fadeSpeed;

    private float t;

    private void Start()
    {
        blackScreen = GetComponent<Image>();

        blackScreen.enabled = true;
    }

    private void Update()
    {
        if (blackScreen.color.a > 0)
        {
            blackScreen.color = Color.Lerp(Color.black,new Color(0, 0, 0, 0), t);

            t += Time.deltaTime * fadeSpeed;
        }
    }
}
