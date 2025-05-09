using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Header("Layer Setting")]
    [SerializeField] private ParallaxLayer[] _layers;

    private Transform _camera;
    private float[] _startPositions;
    private float _boundSizeX;
    private float _sizeX;

    private void Start()
    {
        _camera = Camera.main.transform;
        _sizeX = _layers[0].LayerObject.transform.localScale.x;
        _boundSizeX = _layers[0].LayerObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        _startPositions = new float[_layers.Length];

        for (int i = 0; i < _layers.Length; i++)
        {
            _startPositions[i] = _camera.position.x;
        }
    }

    private void Update()
    {
        for (int i = 0; i < _layers.Length; i++)
        {
            float temp = (_camera.position.x * (1 - _layers[i].LayerSpeed));
            float distance = _camera.position.x * _layers[i].LayerSpeed;

            _layers[i].LayerObject.transform.position = new Vector2(_startPositions[i] + distance, _camera.position.y);

            if (temp > _startPositions[i] + _boundSizeX * _sizeX)
            {
                _startPositions[i] += _boundSizeX * _sizeX;
            }
            else if (temp < _startPositions[i] - _boundSizeX * _sizeX)
            {
                _startPositions[i] -= _boundSizeX * _sizeX;
            }
        }
    }
}