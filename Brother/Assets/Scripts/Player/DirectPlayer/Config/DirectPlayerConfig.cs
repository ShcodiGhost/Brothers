using System;
using UnityEngine;

[Serializable]
public class DirectPlayerConfig
{
    [SerializeField] private Transform _playerHead;
    [SerializeField] private Transform _playerBody;

    public Transform PlayerHead => _playerHead;
    public Transform PlayerBody => _playerBody;
}
