using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextFromFile : MonoBehaviour
{
    [SerializeField]
    private TextAsset _textAssetToCopy;

    [SerializeField]
    private TextMeshProUGUI _textGameObject;

    private void Awake()
    {
        if (_textAssetToCopy.IsUnityNull())
        {
            Debug.LogWarning("There is a missing Text Asset Assignment.");
        }

        if (_textGameObject.IsUnityNull())
        {
            Debug.LogWarning("There is a missing Text Gameobject Assignment.");
        }

        _textGameObject.text = _textAssetToCopy.text;
    }
}
