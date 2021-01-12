using UnityEngine;

public class UnitB : Unit
{
    private MeshRenderer _renderer;
    private Color _origianlColor;
    protected override void Start()
    {
        base.Start();
        _renderer = GetComponent<MeshRenderer>();
        _origianlColor = _renderer.material.color;
    }

    public override void OnSelectUnit()
    {
        _renderer.material.color = Color.magenta;
    }

    public override void OnDeselectUnit()
    {
        _renderer.material.color = _origianlColor;
    }
}
