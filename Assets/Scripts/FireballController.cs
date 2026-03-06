using UnityEngine;

public class FireballController : MonoBehaviour
{
    public float _speed;
    public float _timeToDestroy = 3.25f;
    public GameObject _explosion;

    private void Start()
    {
        //PODEMOS ELIMINAR LA BOLA DE FUEGO POR TIEMPO
        Invoke(nameof(Destroy), _timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.up);

        //PODEMOS ELIMINAR LA BOLA DE FUEGO POR POSICION
        //if (transform.position.y > 50.0f)
        //    DestroyFireball();
    }

    private void Destroy()
    {

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        string collisionGameObjectName = collisionGameObject.tag;

        if (collisionGameObjectName == "Enemy")
        {
            Destroy(collisionGameObject);
            GameObject newExplosion = GameObject.Instantiate(_explosion);
            newExplosion.transform.position = transform.position;
            Destroy();
        }
        
    }

}
