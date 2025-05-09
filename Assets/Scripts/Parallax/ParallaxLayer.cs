using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    [SerializeField] private float _layerSpeed;
    [SerializeField] private GameObject _layerObject;

    public float LayerSpeed => _layerSpeed;
    public GameObject LayerObject => _layerObject;
}