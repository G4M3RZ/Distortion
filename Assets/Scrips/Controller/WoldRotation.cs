using UnityEngine;

public class WoldRotation : MonoBehaviour
{
    [Range(0, 10)] public float _camSpeed;
    [Range(0, 10)] public float _hLimits, _vLimits;
    private Transform _player;

    [HideInInspector] public int _rot;
    [HideInInspector] public bool _move, _jump;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        CamRot();

        if (_rot == -360 || _rot == 360) _rot = 0;

        Vector3 rotation = transform.localEulerAngles;
        rotation.z = Mathf.LerpAngle(rotation.z, _rot, Time.deltaTime * _camSpeed);
        transform.localEulerAngles = rotation;

        _player.localEulerAngles = new Vector3(0, 0, _rot);
    }
    void CamRot()
    {
        float x = _player.position.x;
        float y = _player.position.y;

        if (_move)
        {
            for (int i = -1; i <= 1; i+=2)
                if (x != (_hLimits * i) || y != (_vLimits * i)) _move = false; else return;
        }

        switch (_rot)
        {
            case 0: Condition(x, _hLimits, 1); break;
            case 90: case -270: Condition(y, _vLimits, 1); break;
            case 180: case -180: Condition(x, _hLimits, -1); break;
            case 270: case -90: Condition(y, _vLimits, -1); break;
            default: break;
        }
    }
    void Condition(float pos, float limit, int direction)
    {
        for (int i = -1; i <= 1; i+=2)
        {
            if(pos == limit * i)
            {
                _rot += 90 * i * direction;
                _move = true;
            }
        }
    }
}