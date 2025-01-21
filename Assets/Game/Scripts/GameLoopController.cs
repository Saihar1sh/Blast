using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameLoopController : MonoGenericLazySingleton<GameLoopController>
{
    protected override void Awake()
    {
        base.Awake();
        DOTween.SetTweensCapacity(1000, 100);
    }
    
}
