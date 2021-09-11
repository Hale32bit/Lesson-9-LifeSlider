using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
[DisallowMultipleComponent]
public class HealthView : MonoBehaviour
{
    [SerializeField] private PlayerHealth _health;

    private Slider _slider;
    private Coroutine _changing;

    private float _targetValue;

    private const float ChangingSpeed = 0.3f;

    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _health.Changed += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.Changed -= OnHealthChanged;
    }

    private void OnHealthChanged()
    {
        _targetValue = ((float)_health.Value / (float)_health.Max);
        
        if (_changing != null)
            StopCoroutine(_changing);
        _changing = StartCoroutine(SliderChanging());
    }

    private IEnumerator SliderChanging()
    {
        while (_slider.value != _targetValue)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, _targetValue, ChangingSpeed * Time.deltaTime);
            yield return null;
        }
        yield break;
    }
}
