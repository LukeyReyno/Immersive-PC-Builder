using System.Collections;
using System.Collections.Generic;
using Pixelplacement;
using UnityEngine;

public class ResetPosition : MonoBehaviour
{
    [SerializeField]
    private Camera arCamera;

    private Vector3 _originalPosition;
    private Vector3 _originalDifference;
    
    private void Awake()
    {
        // Because Pivot Position may not be the center of the transform
        _originalPosition = transform.position;
        _originalDifference = _originalPosition - arCamera.transform.forward;
    }

    public void SetNewPosition()
    {
        Quaternion rotation = Quaternion.LookRotation(arCamera.transform.forward, Vector3.up);
        transform.rotation = rotation;
        Tween.Rotate(transform, new Vector3(0, 180f, 0), Space.World, 0.1f, 0);

        transform.position = arCamera.transform.position + _originalDifference + arCamera.transform.forward;
    }
}
