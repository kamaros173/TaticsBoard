using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapInputController : MonoBehaviour {

    private MapCreatorCamera camera;
    private float ver;
    private float hor;
    private float zoom;
    private float rotate;

	// Use this for initialization
	void Start () {
        camera = GetComponent<MapCreatorCamera>();
	}
	
	// Update is called once per frame
	void Update () {
        ver = Input.GetAxis("Vertical");
        hor = Input.GetAxis("Horizontal");
        camera.Move(new Vector3(hor, ver, 0));

        zoom = Input.GetAxis("Mouse ScrollWheel");
        camera.Zoom(zoom);

        rotate = Input.GetAxis("Mouse X");
        camera.Rotate(rotate);


	}
}
