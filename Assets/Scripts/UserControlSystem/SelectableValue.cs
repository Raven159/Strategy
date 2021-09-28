using Abstractions;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Strategy Game/" + nameof(SelectableValue), order = 0)]
public class SelectableValue : ScriptableObject
{
    public ISelectable CurrentValue { get; private set; }
    public Action<ISelectable> OnSelectable;

    public void SetValue(ISelectable value)
    {
        CurrentValue = value;
        OnSelectable?.Invoke(value);
    }
}
