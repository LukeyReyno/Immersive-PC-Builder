using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class TriggerPlacement : MonoBehaviour
{
    public GameObject gameManagerObject;
    public ParticleSystem particle;
    public float duration = 0.5f;

    private void OnTriggerEnter(Collider other)
    {
        print("Triggered by " + other.transform.name);

        gameManagerObject.GetComponent<PlaceARObjectOnHand>().arObject = null;
        other.transform.parent = transform;
        particle.Play();

        if (other.transform.name == "MotherBoard")
        {
            Tween.LocalPosition(other.transform, new Vector3(0.7982459f, -11.28394f, -1.179602f), duration, 0f);
            Tween.LocalRotation(other.transform, Vector3.zero, duration, 0f);
            other.GetComponent<BoxCollider>().isTrigger = false;
        }
        
    }
}
