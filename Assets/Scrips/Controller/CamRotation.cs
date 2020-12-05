using UnityEngine;

public class CamRotation : MonoBehaviour {

    [HideInInspector]
    public float _rotX, _rotZ;

	void Update () 
    {
        Vector3 camRot = transform.localEulerAngles;

        float rotX = (camRot.x <= 180) ? camRot.x : camRot.x - 360;
        _rotX = rotX / 10;

        float rotZ = (camRot.z <= 180) ? camRot.z : camRot.z - 360;
        _rotZ = rotZ / 10;
    }
}