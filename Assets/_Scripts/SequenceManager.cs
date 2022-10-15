using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

using Niantic.ARDK.Utilities.Input.Legacy;

public class SequenceManager : MonoBehaviour
{
    [SerializeField]
    private PlaceARObjectOnHand placeARObjectOnHand;

    [SerializeField]
    private TextMeshProUGUI bodyText;

    [SerializeField]
    private GameObject[] gameObjectOrder;

    [SerializeField]
    private TextAsset sequenceText;

    private string[] _sequenceTextArray;

    private int currentObjectIndex = 0;

    private void Awake()
    {
        bodyText.text = "Loading ...";
        ScanText();
    }

    private void Start()
    {
        bodyText.text = "Welcome to the Immersive PC Builder! This application will show you the steps that are required to put together your very own desktop computer.";
    }

    // Update is called once per frame
    void Update()
    {
        var touch = PlatformAgnosticInput.GetTouch(0);
        if (touch.phase == TouchPhase.Began) // with mouse, mousedown and mouseup both count
        {
            placeARObjectOnHand.SetNewObjectToHold(gameObjectOrder[currentObjectIndex]);
            bodyText.text = _sequenceTextArray[currentObjectIndex];

            if (!gameObjectOrder[currentObjectIndex].IsUnityNull())
                this.gameObject.SetActive(false);

            currentObjectIndex++;
        }
    }

    private void ScanText()
    {
        _sequenceTextArray = sequenceText.ToString().Split('\n');
    }
}
