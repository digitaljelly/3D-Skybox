using UnityEngine;

/*
    This script creates a "3D skybox" effect. 
    
    Q.  What does that mean?
    ========================
    A.  A 3D skybox is one where the skybox contains 3D elements in the distance, that the normal player's 
        camera will never reach.
        This is useful for simulating moons or planets in the sky, airships, megaducks, etc., that don't affect
        gameplay but look cool to have in the sky.
        By using this technique, your objects get caught in shadow cascades, and can benefit from dynamic lighting

    Notes:
    ======
    This doesn't work so great with built-in fog. To fix this, add the FogDensity.cs component
    
    Attach this script to a new GameObject in your scene and configure this script.
*/

[RequireComponent(typeof(Camera))]
public class SkyBoxCamera : MonoBehaviour {

    [Range(0,20000)]
	public float scaleFactor = 20000f;
    public LayerMask cullingMask;
    Vector3 prevPosition, currentPos;
    Transform tf;

    Camera thisCamera;
    Camera mainCamera;
    void Start()
    {
        if (mainCamera != Camera.main)
            mainCamera = Camera.main;
        prevPosition = mainCamera.transform.position;
        MatchCameras(true);
        thisCamera.depth = mainCamera.depth - 1;
        thisCamera.clearFlags = CameraClearFlags.Skybox;
    }


	// Update is called once per frame
	void Update () {
        if (mainCamera != Camera.main)
        {
            mainCamera = Camera.main;
            MatchCameras(true);
        }
        else
        {
            MatchCameras(false);
        }
        tf = mainCamera.transform;
        currentPos = tf.position;
        transform.Translate((currentPos - prevPosition) / scaleFactor);
        prevPosition = currentPos;
        transform.rotation = tf.rotation;
        

    }

    void MatchCameras(bool changeAllValues)
    {
        if(thisCamera == null)
        {
            thisCamera = GetComponent<Camera>();
        }
        thisCamera.fieldOfView = mainCamera.fieldOfView;
        if (changeAllValues)
        {
            thisCamera.cullingMask = cullingMask;
            mainCamera.cullingMask = ~cullingMask.value;
            mainCamera.clearFlags = CameraClearFlags.Depth;
        }
        
    }

}
