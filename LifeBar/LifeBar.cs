using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    public Mesh Mesh;
    public Material Material;

    public float yOffset = 0.1f;
    public float xOffset = 0;

    [Range(0, 1)]public float LifeBarWidth = 1;
    [Range(0, 2)]public float LifeBarHeight = 1;

    MaterialPropertyBlock m_Block;

    public void Display(float3 position, float progress, int split)
    {
        UpdateProperties();
        Draw(position, progress, split);
    }
    public void UpdateProperties()
    {
        if (m_Block == null) m_Block = new MaterialPropertyBlock();
    }

    public void Draw(float3 position, float progress, int split)
    {
        m_Block.SetFloat("_Width", LifeBarWidth);
        m_Block.SetFloat("_Height", LifeBarHeight);
        m_Block.SetFloat("_Progress", progress);
        m_Block.SetColor("_Color", Color.Lerp(Color.red, Color.green, progress));
        m_Block.SetInteger("_Split", split);
        
        Graphics.DrawMesh(Mesh, position + new float3(xOffset, yOffset, 0), quaternion.identity, Material, 0, Camera.main, 0, m_Block);
    }
}