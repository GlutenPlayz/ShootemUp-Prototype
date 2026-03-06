using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float _speed = 5;
    public float _timeToDestroy = 3.25f;
    public GameObject _fireball;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(Destroy), _timeToDestroy);
        float shootRandom = Random.Range(0.5f, 1f);
        Invoke(nameof(Shoot), shootRandom);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(_speed * Time.deltaTime * Vector3.down);

    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void Shoot()
    {
        GameObject newFireball = GameObject.Instantiate(_fireball);
        newFireball.transform.position = transform.position + Vector3.down;
        newFireball.GetComponent<EnemyFireballController>()._shotByEnemy = true;
    }
}
