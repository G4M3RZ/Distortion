using UnityEngine;

public class Scroll : MonoBehaviour {
	
	[HideInInspector]
	public float scroll;

	private Material _mat;
	private float offset;

	private void Awake()
	{
		_mat = GetComponent<Renderer>().material;
	}
	void Update ()
    {
		offset = (offset >= 100) ? offset = 0 : offset += Time.deltaTime * scroll;
		_mat.mainTextureOffset = new Vector2 (0, offset);
	}
}