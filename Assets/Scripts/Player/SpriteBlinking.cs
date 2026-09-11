using UnityEngine;

public class SpriteBlinking : MonoBehaviour
{
    [SerializeField] private float BlinkDecaySpeed = 1f;
    private SpriteRenderer _spriteRenderer;
    private MaterialPropertyBlock _materialPropertyBlock;
    private float _blinkFactor;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _materialPropertyBlock = new MaterialPropertyBlock();
    }

    private void Update()
    {
        if (_blinkFactor <= 0f)
        {
            return;
        }
        _blinkFactor = Mathf.Lerp(_blinkFactor, 0f, Time.deltaTime * BlinkDecaySpeed);
        if (_blinkFactor < 0.01f)
        {
            _blinkFactor = 0f;
        }
        ApplyBlinkFactor();
    }

    public void Blink()
    {
        Debug.Log("blink");
        _blinkFactor = 1f;
        ApplyBlinkFactor();
    }

    private void ApplyBlinkFactor()
    {
            _spriteRenderer.GetPropertyBlock(_materialPropertyBlock);
            _materialPropertyBlock.SetFloat("_BlinkFactor", _blinkFactor);
    }
}
