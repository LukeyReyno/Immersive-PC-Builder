using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Niantic.ARDK.AR;
using Niantic.ARDK.AR.Awareness;
using Niantic.ARDK.AR.Awareness.Semantics;
using Niantic.ARDK.Extensions;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Camera _arCamera;

    [SerializeField]
    private ARSemanticSegmentationManager _semanticManager;

    [SerializeField]
    private RawImage _overlayImage;
    
    private Texture2D _semanticTexture;

    private void Awake()
    {
        
    }

    void Start()
    {
        // Disable screen dimming
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    private void OnEnable() {
        _semanticManager.SemanticBufferUpdated += OnSemanticsBufferUpdated;
    }

    private void OnDisable() {
        _semanticManager.SemanticBufferUpdated -= OnSemanticsBufferUpdated;
    }

    private void OnSemanticsBufferUpdated(ContextAwarenessStreamUpdatedArgs<ISemanticBuffer> args)
    {   
        _overlayImage.gameObject.SetActive(true);
        
        //get the buffer that has been surfaced.
        ISemanticBuffer semanticBuffer = args.Sender.AwarenessBuffer;
        
        //ask for a mask of the sky channel
        int channel = semanticBuffer.GetChannelIndex("ground");

        _semanticManager.SemanticBufferProcessor.CopyToAlignedTextureARGB32
        (
            texture: ref _semanticTexture,
            channel: channel,
            orientation: Screen.orientation
        );

        _overlayImage.texture = _semanticTexture;
    }
}
