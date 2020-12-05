using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeController : MonoBehaviour
{
    [HideInInspector] public string _sceneName;
    [Range(0,10)] public float _speed;

    private Material _mat;
    private Color _fadeColor;

    private void Start()
    {
        _fadeColor = Color.black;
        _fadeColor.a = (_sceneName != "") ? 0 : 1;

        _mat = GetComponent<MeshRenderer>().material;
        _mat.color = _fadeColor;
    }

    private void Update()
    {
        float velocity = Time.deltaTime * _speed;
        _fadeColor.a = (_sceneName != "") ? _fadeColor.a += velocity : _fadeColor.a -= velocity;
        _fadeColor.a = Mathf.Clamp(_fadeColor.a, 0, 1);
        _mat.color = _fadeColor;

        if(_sceneName != "" && _fadeColor.a == 1)
            SceneManager.LoadScene(_sceneName);

        if (_sceneName == "ExitGame" && _fadeColor.a == 1)
            Application.Quit();

        if (_sceneName == "" && _fadeColor.a == 0)
            Destroy(this.gameObject);
    }
}