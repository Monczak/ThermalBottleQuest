using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FunFactPanel : MonoBehaviour
{
    public TMP_Text text;

    public Canvas parentCanvas;
    private RectTransform rectTransform;

    public float screenWidthThreshold;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        TextAsset file = Resources.Load<TextAsset>("ThermosFunFacts");
        string[] lines = file.text.Split('\n');

        text.text = lines[Random.Range(0, lines.Length)];
    }

    private void Update()
    {
        rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Mathf.Min(400, parentCanvas.pixelRect.width - screenWidthThreshold + 400));
    }
}
