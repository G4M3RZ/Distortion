using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCondition : MonoBehaviour
{
    public MeshRenderer _graphic;
    public List<Material> _playerMat;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(SetColor());
    }
    IEnumerator SetColor()
    {
        _graphic.material = _playerMat[1];

        yield return new WaitForSeconds(0.25f);

        _graphic.material = _playerMat[0];
    }
}