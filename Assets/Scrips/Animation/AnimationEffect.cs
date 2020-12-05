using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEffect : MonoBehaviour
{
    [Header("Player graphic")]
    public Animator _anim;
    public MeshRenderer _render;
    [Space]
    public GameObject _velocityFx;
    public List<Scroll> _scroll;
    [Range(0, 2)] public float startSpeed, minSpeed, maxSpeed;
    private float curSpeed;

    private RandomSpawnController _spawner;
    private Player_Movement _moves;

    private void Awake()
    {
        _spawner = transform.GetChild(0).GetComponent<RandomSpawnController>();
        _moves = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        _anim.enabled = _render.enabled = false;

        _spawner.enabled = _moves.enabled = false;
        StartCoroutine(AnimationBegin());
    }
    void SetScrollSpeed(bool condition, float velocity, float limit)
    {
        curSpeed = (condition) ? curSpeed += velocity : curSpeed = limit;
        for (int i = 0; i < _scroll.Count; i++) _scroll[i].scroll = curSpeed;
    }
    IEnumerator AnimationBegin()
    {
        for (int i = 0; i < _scroll.Count; i++) _scroll[i].scroll = curSpeed = -startSpeed;

        while (curSpeed < 0)
        {
            SetScrollSpeed(curSpeed < 0, Time.deltaTime / 2, 0);
            yield return new WaitForEndOfFrame();
        }

        _anim.enabled = _render.enabled = true;

        float time = _anim.GetCurrentAnimatorStateInfo(0).length + _anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
        yield return new WaitForSeconds(time);

        for (int i = 0; i < _scroll.Count; i++) _scroll[i].scroll = curSpeed = maxSpeed;
        Instantiate(_velocityFx, new Vector3(0, 0, 3), Quaternion.identity);

        while (curSpeed > minSpeed)
        {
            SetScrollSpeed(curSpeed > minSpeed, -Time.deltaTime, minSpeed);
            yield return new WaitForEndOfFrame();
        }

        _spawner.enabled = _moves.enabled = true;
    }
}