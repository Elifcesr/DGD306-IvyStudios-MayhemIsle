using System.Collections;
using UnityEngine;

public class DamageFlash : MonoBehaviour
{
    [SerializeField] private Color _flashColor = Color.red;
    [SerializeField] private float _flashTime = 0.25f;

    private SpriteRenderer[] _spriteRenderers;
    private Material[] _materials;
    private Coroutine _damageFlashCoroutine;

    private void Awake()
    {
        _spriteRenderers = GetComponentsInChildren<SpriteRenderer>();

        _materials = new Material[_spriteRenderers.Length];
        for (int i = 0; i < _spriteRenderers.Length; i++)
        {
            _materials[i] = _spriteRenderers[i].material;
        }
    }

    public void CallDamageFlash()
    {
        if (_damageFlashCoroutine != null)
        {
            StopCoroutine(_damageFlashCoroutine);
        }
        _damageFlashCoroutine = StartCoroutine(DamageFlasher());
    }

    private IEnumerator DamageFlasher()
    {
        SetFlashColor();

        float elapsedTime = 0f;
        while (elapsedTime < _flashTime)
        {
            float flashAmount = Mathf.Lerp(1f, 0f, elapsedTime / _flashTime);
            SetFlashAmount(flashAmount);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        SetFlashAmount(0f); 
    }

    private void SetFlashColor()
    {
        foreach (var mat in _materials)
        {
            mat.SetColor("_FlashColor", _flashColor);
        }
    }

    private void SetFlashAmount(float amount)
    {
        foreach (var mat in _materials)
        {
            mat.SetFloat("_FlashAmount", amount);
        }
    }
}
