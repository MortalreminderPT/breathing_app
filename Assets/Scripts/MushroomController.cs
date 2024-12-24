using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    public Vector3 FinalPosition = Vector3.zero;
    public float SmallScale = 1f;
    public float BigScale = 3f;
    public float ScaleSpeed = 2f;

    public float MaxScale = 5f;
    public float MinScale = 0.5f;

    public Transform PresetTransform;
    public Vector3 _presetPosition;
    public Vector3 _presetLocalScale;
    private float _targetScale = 1f;
    private float _currentScale = 1f;
    
    void Start()
    {
        _presetPosition = PresetTransform.position;
        _presetLocalScale = PresetTransform.localScale;
    }

    void Update()
    {
        _currentScale = Mathf.Lerp(_currentScale, _targetScale, Time.deltaTime * ScaleSpeed);
        if (Mathf.Abs(_currentScale - _targetScale) < 0.01f)
        {
            _currentScale = _targetScale;
        }
        this.transform.localScale = _presetLocalScale * _currentScale;
    }

    public void Reset()
    {
        gameObject.transform.position = _presetPosition;
        gameObject.transform.localScale = _presetLocalScale;
        _currentScale = 1f;
        _targetScale = 1f;
    }

    public void ToSmall()
    {
        this.gameObject.transform.position = FinalPosition;
        SetTargetScale(SmallScale);
    }

    public void ToBig()
    {
        this.gameObject.transform.position = FinalPosition;
        SetTargetScale(BigScale);
    }

    public void SetTargetScale(float targetScale)
    {
        _targetScale = Mathf.Clamp(targetScale, MinScale, MaxScale);
        // _targetScale = targetScale;
    }

    public void MultiplyBy(float multiplier)
    {
        float scale = GetTargetScale();
        SetTargetScale(scale * multiplier);
    }

    public void AddBy(float addAmount)
    {
        float scale = GetTargetScale();
        SetTargetScale(scale + addAmount);
    }
    
    public float GetTargetScale()
    {
        return _targetScale;
    }
}
