using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SlottableType
{
    Cube,
    Sphere,
    Triangle
}

public class SlotCollider : MonoBehaviour {

    [SerializeField]
    private Vector3 _lockOffset;
    [SerializeField]
    private SlottableType _slotType;

    void OnTriggerEnter(Collider collider) {

        var slottableObject = collider.GetComponent<Slottable>();

        if (slottableObject != null && slottableObject.Type == _slotType) { // If it is a slottable object and it's the same slot type (I.E not a sphere and square)
            // Move object to the lockOffset location and freeze any movement (Lock it in place)
            collider.GetComponent<Rigidbody>().isKinematic = true;
            collider.transform.SetParent(this.transform);
            collider.transform.localPosition = _lockOffset;
            collider.transform.rotation = this.transform.rotation;
        }

    }
}
