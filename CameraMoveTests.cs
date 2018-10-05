using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveTests : MonoBehaviour {

    public float moveSpeed = 1f;
    public float rotationSpeed = 30f;

    Vector2 lastMouse;

    void Start()
    {
        lastMouse = (Vector2) Input.mousePosition;
    }
	// Update is called once per frame
	void Update () {
        transform.Translate(transform.forward * moveSpeed * Time.deltaTime * Input.GetAxis("Vertical"));
        transform.Translate(transform.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
        Vector2 mouseDelta = (Vector2)Input.mousePosition - lastMouse;
        transform.Rotate(Vector3.up, (mouseDelta.x / Screen.width) * rotationSpeed * Time.deltaTime, Space.World);
        transform.Rotate(transform.right, (-mouseDelta.y / Screen.height) * rotationSpeed * Time.deltaTime, Space.World);
        lastMouse = Input.mousePosition;
    }
}
