using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public float boundarySize;
    public float camSpeed;
    public float camZoomMultiplier;
    public float minHeight;
    float minDistHeight;
    public float maxHeight;
    float maxDistHeight;
    public float rotateExtent;

    public bool camLock = true;

    Vector3 myOriginalRotation;
    public Vector3 maxZoomRotation;
    Vector3 myOriginalForward;

    Vector2 camDir;

    Vector2 mouseCenter = new Vector2(Screen.width / 2, Screen.height / 2);
    Vector2 mousePos;

    Vector2 posBorder;
    Vector2 negBorder;

    Vector3 targetPosition;

    void Start() {
        myOriginalRotation = transform.eulerAngles;
        myOriginalForward = transform.forward;
        targetPosition = transform.position;
        posBorder = new Vector2(Screen.width - boundarySize, Screen.height - boundarySize);
        negBorder = new Vector2(boundarySize, boundarySize);
    }

    void Update() {
        if (!camLock) {
            mousePos = Input.mousePosition;
            if (Input.mousePosition.x > posBorder.x || Input.mousePosition.y > posBorder.y || Input.mousePosition.x < negBorder.x || Input.mousePosition.y < negBorder.y) {
                MoveCamera();
            }
            if (Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f) {
                ZoomCamera();
            }
            CameraLerp();
        }
    }
    void MoveCamera() {
        camDir = (mousePos - mouseCenter).normalized;
        targetPosition += new Vector3(camDir.x * camSpeed, 0, camDir.y * camSpeed);
    }

    void ZoomCamera() {
        if ((targetPosition.y < maxHeight - 1f && Input.GetAxis("Mouse ScrollWheel") < 0f)
            || (targetPosition.y > minHeight + 1f && Input.GetAxis("Mouse ScrollWheel") > 0f))
            targetPosition += myOriginalForward * Input.GetAxis("Mouse ScrollWheel") * camZoomMultiplier;
    }

    void CameraLerp() {
        if (transform.position != targetPosition) {
            targetPosition = new Vector3(targetPosition.x, Mathf.Clamp(targetPosition.y, minDistHeight, maxDistHeight), targetPosition.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, 0.1f);
        }
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -Vector3.up, out hit)) {
            minDistHeight = hit.transform.position.y + minHeight;
            maxDistHeight = hit.transform.position.y + maxHeight;
            if (transform.position.y < rotateExtent) {
                transform.eulerAngles = Vector3.Lerp(maxZoomRotation, myOriginalRotation, (transform.position.y - minHeight) / (rotateExtent - minHeight));
            }
        }
    }
}