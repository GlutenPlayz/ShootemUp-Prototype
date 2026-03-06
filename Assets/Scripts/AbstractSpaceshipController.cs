using UnityEngine;

public abstract class AbstractSpaceshipController : MonoBehaviour
{
    public GameObject _fireball;
    public float _speed;
    protected Vector3 _minWorldPoint;
    protected Vector3 _maxWorldPoint;

    protected virtual void Update()
    {
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;
        Vector2 topRightScreenCorner = new Vector2(screenWidth, screenHeight);
        Camera camera = Camera.main;
        _maxWorldPoint = camera.ScreenToWorldPoint(topRightScreenCorner);
        _minWorldPoint = camera.ScreenToWorldPoint(new Vector2());

        Vector2 direction = SpaceshipDirection();
        SpaceshipTranslate(direction);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newFireball = GameObject.Instantiate(_fireball);
            newFireball.transform.position = transform.position + new Vector3(0,0.7f,0);
        }
    }

    private void SpaceshipTranslate(Vector3 direction)
    {
        if(CanMove())
            transform.Translate(direction * _speed * Time.deltaTime);

        ClampPosition();
    }

    private bool CanMove()
    {
        return transform.position.x >= _minWorldPoint.x && 
               transform.position.x <= _maxWorldPoint.x && 
               transform.position.y >= _minWorldPoint.y && 
               transform.position.y <= _maxWorldPoint.y;
    }

    private void ClampPosition()
    {
        float campledXPosition = Mathf.Clamp(transform.position.x, _minWorldPoint.x, _maxWorldPoint.x);
        float campledYPosition = Mathf.Clamp(transform.position.y, _minWorldPoint.y, _maxWorldPoint.y);
        Vector3 campledPosition = new Vector3(campledXPosition, campledYPosition);
        transform.position = campledPosition;
    }
    protected Vector2 SpaceshipDirection()
    {
        Vector2 direction = Vector2.zero;

        if (InputUp())
            direction += Vector2.up;

        if (InputDown())
            direction += Vector2.down;

        if (InputRight())
            direction += Vector2.right;

        if (InputLeft())
            direction += Vector2.left;

        return direction.normalized;
    }

    protected abstract bool InputUp();
    protected abstract bool InputDown();
    protected abstract bool InputLeft();
    protected abstract bool InputRight();
}
