using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaceARObjectOnHand : MonoBehaviour
{
    [SerializeField] private HandPositionSolver handPositionSolver;
    public GameObject arObject;
    [SerializeField] private float speedMovement = 0.5f;
    [SerializeField] private float speedRotation = 25.0f;

    private float minDistance = 0.05f;
    private float minAngleMagnitude = 2.0f;
    private bool shouldAdjustRotation;

    private void Update()
    {
        if (!arObject.IsUnityNull())
            PlaceObjectOnHand(handPositionSolver.HandPos);
    }

    private void PlaceObjectOnHand(Vector3 handPos)
    {
        float distance = Vector3.Distance(handPos, arObject.transform.position);
        arObject.transform.position = Vector3.MoveTowards(arObject.transform.position, handPos, speedMovement * Time.deltaTime);
        if (distance >= minDistance)
        {
            arObject.transform.LookAt(handPos);
            shouldAdjustRotation = true;
        }
        else
        {
            if (shouldAdjustRotation)
            {
                arObject.transform.rotation = Quaternion.Slerp(arObject.transform.rotation, Quaternion.identity, 2 * Time.deltaTime);
                Vector3 angles = arObject.transform.rotation.eulerAngles;
                shouldAdjustRotation = angles.magnitude >= minAngleMagnitude;
            }
            else
            {
                arObject.transform.Rotate(Vector3.up*speedRotation*Time.deltaTime);
            }
        }
    }

    public void SetNewObjectToHold(GameObject gameObject)
    {
        this.arObject = gameObject;
    }
}
