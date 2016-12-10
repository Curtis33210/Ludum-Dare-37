using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum CheckpointEvents
{
    //GoToNextLevel,
    GoToLevel,
    //GoToPreviousLevel,
}

public class CheckpointMover : MonoBehaviour {

    private EventManager _eventManager;
    private float _moveTime = 3f;

    public Location[] _checkpointTransforms;

    
	private void Awake () {
        _eventManager = new EventManager();

        _eventManager.RegisterListener(CheckpointEvents.GoToLevel, MoveToCheckpoint);
	}

    private void MoveToCheckpoint(GameEvent e) {
        int index = (int)e.Args;
        
        StartCoroutine("MoveTo", index);
    }

    private IEnumerator MoveTo(int index) {

        index = index % (_checkpointTransforms.Length); // TODO:  Remove Later

        var targetLocation = _checkpointTransforms[index].Position;
        var targetRotation = _checkpointTransforms[index].Rotation;
        var targetScale = _checkpointTransforms[index].Scale;

        var startPos = transform.position;
        var startRot = transform.rotation.eulerAngles;
        var startScale = transform.localScale;

        var timeSinceStart = 0f;
        var percentageLerp = 0f;

        while (percentageLerp < 1) {

            percentageLerp = timeSinceStart / _moveTime;

            var newLocation = Vector3.Lerp(startPos, targetLocation, timeSinceStart / _moveTime);
            var newRotation = Vector3.Lerp(startRot, targetRotation, timeSinceStart / _moveTime);
            var newScale = Vector3.Lerp(startScale, targetScale, timeSinceStart / _moveTime);

            transform.position = newLocation;
            transform.rotation = Quaternion.Euler(newRotation);
            transform.localScale = newScale;

            timeSinceStart += Time.deltaTime;
            yield return null;
        }

        transform.position = targetLocation;
        transform.rotation = Quaternion.Euler(targetRotation);
        transform.localScale = targetScale;
    }
}

[Serializable]
public struct Location
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;
}
