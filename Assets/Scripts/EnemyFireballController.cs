using UnityEngine;

public class EnemyFireballController : MonoBehaviour
{
    public float _speed;
    public float _timeToDestroy = 3.25f;
    public bool _shotByEnemy = false;
    public GameObject _explosion;

    private void Start()
    {
        //PODEMOS ELIMINAR LA BOLA DE FUEGO POR TIEMPO
        Invoke(nameof(Destroy), _timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

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

        AbstractSpaceshipController spaceshipController = collisionGameObject.GetComponent<AbstractSpaceshipController>();

        if (spaceshipController != null)
        {
            Destroy(collisionGameObject);
            GameObject newExplosion = GameObject.Instantiate(_explosion);
            newExplosion.transform.position = transform.position;
            Destroy();
        }
    }
}
