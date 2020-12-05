using UnityEngine;

public class Obs : MonoBehaviour
{
    private RandomSpawnController _ctrl;
    private Rigidbody _rgb;

    private void Awake()
    {
        _ctrl = GetComponentInParent<RandomSpawnController>();
        _rgb = GetComponent<Rigidbody>();

        int random = Random.Range(0, 2);
        int rot = (random == 0) ? 0 : 180;
        transform.localEulerAngles = new Vector3(0, 0, rot);
    }
    private void FixedUpdate()
    {
        _rgb.velocity = transform.forward * _ctrl._obsVelocity * 5;

        if(transform.position.z < -100) Destroy(this.gameObject);
    }
}