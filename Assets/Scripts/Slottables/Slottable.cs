using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slottable : MonoBehaviour {

    [SerializeField]
    private SlottableType _type;
    public SlottableType Type { get { return _type; } }

}
