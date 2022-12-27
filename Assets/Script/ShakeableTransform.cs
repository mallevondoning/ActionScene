using UnityEngine;

public class ShakeableTransform : MonoBehaviour
{
    public static ShakeableTransform Instance { get; set; }

    [SerializeField]
    private Vector3 _maximumTranslationShake = Vector3.one * 0.5f;
    [SerializeField]
    private Vector3 _maximumAngularShake = Vector3.one * 2f;
    [SerializeField]
    private float _frequency = 25;
    [SerializeField]
    private float _recoverySpeed = 1.5f;
    [SerializeField]
    private float _traumaExponent = 2;

    private float _seed;
    private float _trauma = 0;

    private void Awake()
    {
        Instance = this;

        _seed = Random.value;
    }

    void Update()
    {
        float shake = Mathf.Pow(_trauma,_traumaExponent);

        transform.localPosition = new Vector3(
                                  _maximumTranslationShake.x * (Mathf.PerlinNoise(_seed, Time.time * _frequency) * 2 - 1),
                                  _maximumTranslationShake.y * (Mathf.PerlinNoise(_seed + 1, Time.time * _frequency) * 2 - 1),
                                  _maximumTranslationShake.z * (Mathf.PerlinNoise(_seed + 2, Time.time * _frequency) * 2 - 1)) * _trauma;

        transform.localRotation = Quaternion.Euler(new Vector3(
                                  _maximumAngularShake.x * (Mathf.PerlinNoise(_seed + 3, Time.time * _frequency) * 2 - 1),
                                  _maximumAngularShake.y * (Mathf.PerlinNoise(_seed + 4, Time.time * _frequency) * 2 - 1),
                                  _maximumAngularShake.z * (Mathf.PerlinNoise(_seed + 5, Time.time * _frequency) * 2 - 1)) * _trauma);

        _trauma = Mathf.Clamp01(_trauma - _recoverySpeed * Time.deltaTime);
    }

    public void InduceStress(float stress)
    {
        _trauma = Mathf.Clamp01(_trauma + stress);
    }
}