using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoGenericLazySingleton<CubeManager>
{
    public List<List<CubeController>> spawnedCubes;
    public CubeController[] shootableCubes;

    public CubeController cubePrefab;

    public Transform _spawnPoint;

    private readonly Vector2 offset = new Vector2(0.1f, .1f);

    //private char seperator = ',';
    protected override void Awake()
    {
        base.Awake();
        spawnedCubes = new List<List<CubeController>>(10);
        shootableCubes = new CubeController[10];

        SpawnedCubes();
    }

    private void SpawnedCubes()
    {
        for (int i = 0; i < 10; i++)
        {
            List<CubeController> _cubeControllers = new List<CubeController>();
            for (int j = 0; j < 40; j++)
            {
                var cube = Instantiate(cubePrefab, _spawnPoint);
                _cubeControllers.Add(cube);
                    cube.Init(""+i+j, GetCubePosition(i,j));
            }

            spawnedCubes.Add(_cubeControllers);
        }
    }

    private Vector3 GetCubePosition(int i,int j)
    {
        return new Vector3( i + i * offset.x, 0, -1*(j + j * offset.y));
    }

    public void Start()
    {
    }

    public void RearrangeCubes(int cubeIndex)
    {
        var listToArrange = spawnedCubes[cubeIndex];
        for (int i = 0; i < listToArrange.Count; i++)
        {
            listToArrange[i].MoveToPosition(GetCubePosition(cubeIndex, i), 0.1f);
        }
    }

    public void RemoveCube(CubeController cube)
    {
        /*var _index = index.Split(seperator, StringSplitOptions.RemoveEmptyEntries);
        int i = int.Parse(_index[0]);
        int j = int.Parse(_index[1]);*/

        int cubeIndex = int.Parse(cube.Index[0]+"");
        spawnedCubes[cubeIndex].Remove(cube);
        
        RearrangeCubes(cubeIndex);

    }
}