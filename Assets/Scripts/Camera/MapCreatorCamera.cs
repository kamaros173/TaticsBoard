using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreatorCamera : MonoBehaviour {

    public float xMax, yMax, zMax;
    public float xMin, yMin, zMin;
    public float moveSpeed;

    private Vector3 moveTarget;
    private Quaternion rotateTarget;
    private Vector3 zoomTarget;

    public void Move(Vector3 dir)
    {
        moveTarget = transform.position + (dir.normalized * Time.deltaTime * moveSpeed);
        moveTarget.x = Mathf.Clamp(moveTarget.x, xMin, xMax);
        moveTarget.y = Mathf.Clamp(moveTarget.y, yMin, yMax);
        transform.position = moveTarget;
    }

    public void Rotate(float rot)
    {
        transform.Rotate(0, rot, 0);
    }

    public void Zoom(float dir)
    {
        zoomTarget = transform.position + (transform.forward * dir * Time.deltaTime * moveSpeed);
        zoomTarget.z = Mathf.Clamp(zoomTarget.z, zMin, zMax);
        zoomTarget.x = Mathf.Clamp(zoomTarget.x, xMin, xMax);
        zoomTarget.y = Mathf.Clamp(zoomTarget.y, yMin, yMax);
        transform.position = zoomTarget;
    }
}
