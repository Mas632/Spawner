using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class StarshipSpawner : MonoBehaviour
{
    [Tooltip("����� � �������� ����� ����� ���������������� ���������� ����������� ��������")]
    [SerializeField] private float _timeBetweenSpawns;
    [Tooltip("�������� ������������ ������������ �������")]
    [SerializeField] private Starship _starshipPrototype;
    [Tooltip("�����, � ������� ����� ���������� ����� �������")]
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [Tooltip("�����������, � ������� ����� ������ ����������� �������")]
    [SerializeField] private Vector3 _starshipForceDirection;

    private Coroutine _spawnStarshipsProccess;

    private void OnEnable()
    {
        _spawnStarshipsProccess = StartCoroutine(SpawnStarships());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnStarshipsProccess);
    }

    private IEnumerator SpawnStarships()
    {
        var delay = new WaitForSecondsRealtime(_timeBetweenSpawns);

        while (true)
        {
            yield return delay;

            CreateStarship();
        }
    }

    private void CreateStarship()
    {
        Starship starship = Instantiate(_starshipPrototype, _spawnPoints[Random.Range(0, _spawnPoints.Length)].transform.position, Quaternion.identity);

        starship.ChangeForceDirection(_starshipForceDirection.normalized);
    }
}
