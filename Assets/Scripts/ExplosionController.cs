using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    public float _timeToDestroy = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(Destroy), _timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
