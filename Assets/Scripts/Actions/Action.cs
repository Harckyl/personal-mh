using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NewAction", menuName = "ScriptableObjects/Action", order = 2)]
public class Action : ScriptableObject
{
    [SerializeField] string _actionName;
    public string actionName => _actionName;

    [SerializeField] string _actionButton;
    public string actionButton => _actionButton;

    [SerializeField] float _actionTime;
    public float ActionTime => _actionTime;

    [SerializeField] Action[] _nextAction;
    public Action[] nextAction => _nextAction;
}
