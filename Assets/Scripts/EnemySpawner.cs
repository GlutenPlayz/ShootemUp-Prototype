using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject _enemyPrefab;
    private Vector3 _minWorldPoint;
    private Vector3 _maxWorldPoint;
    public float _spawnRate = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        InvokeRepeating(nameof(Spawn), _spawnRate, _spawnRate);
        Vector2 topRightScreenCorner = new Vector2(screenWidth, screenHeight);
        Camera camera = Camera.main;
        _maxWorldPoint = camera.ScreenToWorldPoint(topRightScreenCorner);
        _minWorldPoint = camera.ScreenToWorldPoint(new Vector2());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Spawn()
    {
        GameObject enemyInstance = GameObject.Instantiate(_enemyPrefab);

        float xRandom = Random.Range(_minWorldPoint.x, _maxWorldPoint.x);

        enemyInstance.transform.position = new Vector2(xRandom, 7);
    }
}
