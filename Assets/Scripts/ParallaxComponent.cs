using UnityEngine;

//Con este atributo obligamos al gameObject que posea este codigo para que tenga un componente, SI O SI, de tipo Mesh Renderer
[RequireComponent (typeof(MeshRenderer))]
public class ParallaxComponent : MonoBehaviour
{
    public float _speed;

    private MeshRenderer _meshRenderer;
    private Material _material;
    private Vector2 _offset;

    private void Start()
    {
        // _meshRenderer = GetComponent<MeshRenderer>(); //Con este metodo podemos "capturar" un componente. En este caso, del mismo gameObject sobre el que se encuentre este código (script).
        _material = GetComponent<MeshRenderer>().material;
    }

    private void Update()
    {
        _offset += Vector2.up * _speed * Time.deltaTime; //Utilizamos la formula que hemos usado hasta ahora (dirección * velocidad * deltaTime) para calcular el desplazamiento del offset de la textura del material
        _material.mainTextureOffset = _offset;
        // GetComponent<MeshRenderer>().material.mainTextureOffset = _offset;
    }
}
