using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Range(0, 10)] public float _speed, _fallSpeed, _rotSpeed;
    private CamRotation _cam;
    private WoldRotation _wr;

    private void Awake()
    {
        GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
        _cam = cam.GetComponent<CamRotation>();
        _wr = cam.GetComponentInParent<WoldRotation>();
    }
    private void Update()
    {
        //Get Position (cambiar por rgb)
        Vector3 pos = transform.position;

        //Horizontal Move
        float velocity = -_cam._rotZ * Time.deltaTime * _speed;
        pos += transform.right * velocity;

        //Vertical Move
        pos -= transform.up * Time.deltaTime * _fallSpeed * 3;

        Jump();

        //Limit Moves
        pos.x = Mathf.Clamp(pos.x, -_wr._hLimits, _wr._hLimits);
        pos.y = Mathf.Clamp(pos.y, -_wr._vLimits, _wr._vLimits);

        //Set Moves
        transform.position = pos;
    }
    void Jump()
    {
        if (_cam._rotX <= -1 && !_wr._jump)
        {
            _wr._rot = (_wr._rot > 0) ? _wr._rot -= 180 : _wr._rot += 180;
            _wr._jump = true;
        }
        else if (_cam._rotX > -1) _wr._jump = false;
    }
}