using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    private void Awake()
    {
        float time = GetComponent<ParticleSystem>().main.duration;
        Destroy(this.gameObject, time * 1.5f);
    }
}