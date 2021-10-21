﻿using Abstractions;
using System;
using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TopPanelPresenter : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private Button _menuButton;
    [SerializeField] private GameObject _menuGameObject;

    [Inject]
    private void Init(ITimeModel timeModel)
    {
        timeModel.GameTime.Subscribe(seconds =>
        {
            var t = TimeSpan.FromSeconds(seconds);
            _inputField.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        });

        _menuButton.OnClickAsObservable().Subscribe(_ => _menuGameObject.SetActive(true));
    }
}
