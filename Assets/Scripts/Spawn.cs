using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    [SerializeField] private GameObject _spawnPrefab;

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint = 0;

    void Start()
    {
        _spawnPoints = new Transform[_spawn.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _spawn.GetChild(i);

        var spawner = StartCoroutine(StartSpawnPrefabs());
    }

    private IEnumerator StartSpawnPrefabs()
    {
        while(true)
        {
            if (_currentSpawnPoint == _spawnPoints.Length)
                _currentSpawnPoint = 0;

            GameObject newObject = Instantiate(_spawnPrefab, _spawnPoints[_currentSpawnPoint].position, Quaternion.identity);
            _currentSpawnPoint++;
            yield return new WaitForSeconds(2);
        }
    }
}
