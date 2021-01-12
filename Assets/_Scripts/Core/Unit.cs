using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Unit : MonoBehaviour
{
    [SerializeField] private string unitUnitName;

    public string GetUnitName
    {
        get { return unitUnitName; }
    }

    [SerializeField] private NavMeshAgent mAgent;
    [SerializeField] private Indicator indicator;
    protected virtual void Start() => mAgent = mAgent ? mAgent : GetComponent<NavMeshAgent>();

    public virtual void Move(Vector3 position)
    {
        mAgent.SetDestination(position);
        OnDeselectUnit();
    }

    //Virtual In case the method need to be override in the child class
    public virtual void OnSelectUnit() => indicator.SetState(true);

    //Virtual In case the method need to be override in the child class
    public virtual void OnDeselectUnit() => indicator.SetState(false);
}
