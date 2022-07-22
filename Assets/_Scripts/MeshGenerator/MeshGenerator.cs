using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshGenerator : MonoBehaviour
{
    public Mesh mesh;
    public Vector3[] vertices;
    public int[] triangles;
    public Vector2[] uvs;
    public Color[] colors;

    public int xSize = 20;
    public int zSize = 20;

    public bool GrawGizmos = false;
    public bool DrawColor = true;

    public MeshCollider MeshCollider;

    public Gradient gradient;

    public float minTerrainHeight;
    public float maxTerrainHeight;
    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        MeshCollider = GetComponent<MeshCollider>();
        MeshCollider.sharedMesh = mesh;
    }
    
    private void Update()
    {
        CreateShape();
        UpdateMesh();
    }

    public float xNoiseScale = 0.3f;
    public float zNoiseScale = 0.3f;
    public float perlinNoiseScale = 2f;
    public float xNoiseTimeScale = 1f;
    public float zNoiseTimeScale = 1f;
    

    public void CreateShape()
    {

        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Mathf.PerlinNoise(x * xNoiseScale + (Time.time * xNoiseTimeScale), z * zNoiseScale + (Time.time *
                    zNoiseTimeScale)) * perlinNoiseScale;
                vertices[i] = new Vector3(x, y, z);

                if (y > maxTerrainHeight)
                    maxTerrainHeight = y;
                if (y < minTerrainHeight)
                    minTerrainHeight = y;
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];
        
        int vert = 0;
        int tris = 0;
        for (int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {

                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }

        uvs = new Vector2[vertices.Length];
        
        for (int i = 0, z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                uvs[i] = new Vector2((float)x / xSize, (float)z / zSize);
                i++;
            }
        }

        if (DrawColor)
        {
            colors = new Color[vertices.Length];
            for (int i = 0, z = 0; z <= zSize; z++)
            {
                for (int x = 0; x <= xSize; x++)
                {
                    float height = Mathf.InverseLerp(minTerrainHeight,maxTerrainHeight,vertices[i].y);
                    colors[i] = gradient.Evaluate(height);
                    i++;
                }
            }
        }
    }

    public void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        mesh.colors = colors;
        
        mesh.RecalculateNormals();
        MeshCollider.sharedMesh = mesh;
    }

    private void OnDrawGizmos()
    {
        if (vertices == null)
            return;
        if (!GrawGizmos)
            return;
        for (int i = 0; i < vertices.Length; i++)
        {
            Gizmos.DrawSphere(vertices[i], .1f);
        }
    }

}
