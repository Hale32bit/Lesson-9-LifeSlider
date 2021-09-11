using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerHealth : MonoBehaviour
{
    public event Action Changed;

    private int _value = MaxValue;

    public int Value => _value;
    public int Max => MaxValue;

    private const int MaxValue = 100;
    private const int MinValue = 0;

    public void Add(int increment)
    {
        _value += increment;
        ClipHealth();
        Changed?.Invoke();
    }

    private void ClipHealth()
    {
        if (_value < MinValue)
            _value = MinValue;
        if (_value > MaxValue)
            _value = MaxValue;
    }
}
