using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    private Transform _transform;
    public GameObject tarjet;
    private float x;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }

    void Update()
    {
        x = tarjet.transform.position.x;
        _transform.position = new Vector3(x + 5, _transform.position.y, _transform.position.z);
    }
}
