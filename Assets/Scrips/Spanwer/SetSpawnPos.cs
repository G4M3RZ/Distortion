using UnityEngine;

[ExecuteInEditMode]
public class SetSpawnPos : MonoBehaviour
{
    public bool _active;
    [Range(0, 100)] public float _pos;
    private Transform _spawn;

    private void Awake()
    {
        _spawn = transform.GetChild(0);
        _active = this.enabled = false;
    }
    private void Update()
    {
        if (_active)
        {
            _spawn.position = new Vector3(0, 0, _pos);
            _spawn.localEulerAngles = new Vector3(0, 180, 0);
        }
    }
}