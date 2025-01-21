using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using UnityEngine.Rendering;

public class CubeController : MonoBehaviour
{
    public string Index { get; private set; }
    [SerializeField] private float _scaleDuration = 0.1f;
    
    public void Init(string index, Vector3 position)
    {
        Index = index;
        name = index;
        var _transform = transform;
        _transform.localPosition = position;
        _transform.localScale = Vector3.zero;
        UpScaleTween();
    }

    private Tween UpScaleTween()
    {
        return transform.DOScale(1, _scaleDuration);
    }
    private Tween DownScaleTween()
    {
        return transform.DOScale(0, _scaleDuration);
    }

    public void MoveToPosition(Vector3 position, float duration)
    {
        transform.DOLocalMove(position, duration);
    }

    public void OnShot()
    {
        DownScaleTween();
        CubeManager.instance.RemoveCube(this);
        AndroidManager.HapticFeedback();
    }

    private void OnMouseUp()
    {
        OnShot();
    }
}
