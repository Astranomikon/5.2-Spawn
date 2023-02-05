using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private Mob _spawnMob;

    private WaitForSeconds _sleep = new WaitForSeconds(2);

    private Transform[] _spawnPoints;
    private int _currentSpawnPoint = 0;

    private void Start()
    {
        _spawnPoints = new Transform[_spawner.childCount];

        for (int i = 0; i < _spawnPoints.Length; i++)
            _spawnPoints[i] = _spawner.GetChild(i);

        var spawnMobs = StartCoroutine(StartSpawnPrefabs());
    }

    private IEnumerator StartSpawnPrefabs()
    {
        while(true)
        {
            if (_currentSpawnPoint == _spawnPoints.Length)
                _currentSpawnPoint = 0;

            var spawnedMob = Instantiate(_spawnMob, _spawnPoints[_currentSpawnPoint].position, Quaternion.identity);
            _currentSpawnPoint++;
            yield return _sleep;
        }
    }
}
