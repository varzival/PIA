using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class QuizButton : MonoBehaviour
{
    public Image theButton;

    // Use this for initialization
    void Start()
    {
        GetComponent<Image>().alphaHitTestMinimumThreshold = 0.3f;
    }
}
