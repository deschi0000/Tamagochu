using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{

    public RectTransform feedButton;
    public RectTransform cleanButton;
    public RectTransform playButton;
    public RectTransform healthButton;
    public RectTransform poopButton;
    public RectTransform readButton;

    public TMP_Text debugLabel;

    // Get the scaling for the different devices
    public CanvasScaler scaler;
    public Vector2 scale;



    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.currentResolution);

        // Caclulate what the new resolution is
        var currentResolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);

        // Calculate what the new scale is based off the ref resolution (Samsung S9)
        scale = currentResolution / scaler.referenceResolution;

        Debug.Log($"Resolution: {Screen.currentResolution}");
        Debug.Log($"Scale: {scale}");

        setButtonPositions();


    }

    // Update is called once per frame
    void Update()
    {

    }

    // Lets keep it awake for now
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void setButtonPositions()
    {

        // Safe area bounds
        float safeLeft = Screen.safeArea.xMin;
        float safeRight = Screen.safeArea.xMax;
        float safeTop = Screen.safeArea.yMax;
        float safeBottom = Screen.safeArea.yMin;

        // Calculate top and bottom row Y positions (90% and 10% of height within safe area)
        float topRow = safeTop - (safeTop - safeBottom) * 0.1f; // 10% down from the top of the safe area
        float bottomRow = safeBottom + (safeTop - safeBottom) * 0.1f; // 10% up from the bottom of the safe area

        // Calculate left, center, and right X positions
        float leftThird = safeLeft + (safeRight - safeLeft) * 0.2f; // 20% into the safe area
        float center = safeLeft + (safeRight - safeLeft) * 0.5f; // 50% into the safe area
        float rightThird = safeLeft + (safeRight - safeLeft) * 0.8f; // 80% into the safe area

        // Position top row buttons
        feedButton.position = new Vector2(leftThird, topRow);
        cleanButton.position = new Vector2(center, topRow);
        playButton.position = new Vector2(rightThird, topRow);

        // Position bottom row buttons
        healthButton.position = new Vector2(leftThird, bottomRow);
        poopButton.position = new Vector2(center, bottomRow);
        readButton.position = new Vector2(rightThird, bottomRow);

    }
}
