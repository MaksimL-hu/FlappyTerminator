using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] private bool _cameraMove;
    [SerializeField] private float _cameraMoveSpeed = 1.5f;

    [Header("Layer Setting")]
    [SerializeField] private float[] _layerSpeed;
    [SerializeField] private GameObject[] _layerObjects;

    private Transform _camera;
    private float[] _startPositions;
    private float _boundSizeX;
    private float _sizeX;

    void Start()
    {
        if(_layerSpeed.Length != _layerObjects.Length)
        {
            Debug.LogWarning("The Length of Layer Speed and Layer Objects doesn't equal");
        }

        _camera = Camera.main.transform;
        _sizeX = _layerObjects[0].transform.localScale.x;
        _boundSizeX = _layerObjects[0].GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        _startPositions = new float[_layerSpeed.Length];

        for (int i = 0; i < _layerSpeed.Length; i++)
        {
            _startPositions[i] = _camera.position.x;
        }
    }

    void Update()
    {
        if (_cameraMove)
        {
            _camera.position += Vector3.right * Time.deltaTime * _cameraMoveSpeed;
        }

        for (int i = 0; i < _layerSpeed.Length; i++)
        {
            float temp = (_camera.position.x * (1 - _layerSpeed[i]));
            float distance = _camera.position.x * _layerSpeed[i];

            _layerObjects[i].transform.position = new Vector2(_startPositions[i] + distance, _camera.position.y);

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