using UnityEngine;


[CreateAssetMenu(fileName = "NewActionCollection", menuName = "ScriptableObjects/ActionCollection", order = 1)]
public class ActionCollection : ScriptableObject
{
    [SerializeField] Action[] _hunterAction;
}
