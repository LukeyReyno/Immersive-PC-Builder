using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARDK.Extensions;
using Niantic.ARDK.AR.Awareness;

public class HandPositionSolver : MonoBehaviour
{
    [SerializeField] private ARHandTrackingManager handTrackingManager;
    [SerializeField] private Camera arCamera;
    [SerializeField] private float minHandConfidence = 0.85f;

    private Vector3 handPos;
    public Vector3 HandPos { get => handPos; }
    
    private void Start()
    {
        handTrackingManager.HandTrackingUpdated += HandTrackingUpdated;
    }

    private void OnDestroy()
    {
        handTrackingManager.HandTrackingUpdated -= HandTrackingUpdated;
    }

    private void HandTrackingUpdated(HumanTrackingArgs handData)
    {
        var detections = handData.TrackingData?.AlignedDetections;
        if (detections == null)
        {
            return;
        }
        foreach (var detection in detections)
        {
            if (detection.Confidence < minHandConfidence)
            {
                return;
            }
            Vector3 detectionSize = new Vector3(detection.Rect.width, detection.Rect.height, 0);
            float depthEstimation = 0.2f + Mathf.Abs(1 - detectionSize.magnitude);

            handPos = arCamera.ViewportToWorldPoint(new Vector3(detection.Rect.center.x, 1 - detection.Rect.center.y, depthEstimation));

        }
    }
}
