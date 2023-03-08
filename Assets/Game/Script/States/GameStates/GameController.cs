using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private float _tapLimitDuration = 2.5f;

    [Header("Dependencies")]
    //[SerializeField] private Unit _playerUnitPrefab;
    //[SerializeField] private Transform _playerUnitSpawnLocation;
    //[SerializeField] private UnitSpawner _unitSpawner;

    [SerializeField] private TouchManager _touch;

    // sound effects
    [SerializeField] protected AudioClip _winSound;
    [SerializeField] protected AudioClip _loseSound;

    [SerializeField] Text _gameplayState;
    [SerializeField] Text _loadSave;
    [SerializeField] Text _spawnUnits;
    [SerializeField] Text _gameplay;
    [SerializeField] Text _playerInputs;
    [SerializeField] Text _playerHUD;

    [SerializeField] private Transform _minPoint;
    [SerializeField] private Transform _maxPoint;

    public float _timeCooldown = 0;
    public float SpawnCooldown = 2;

    [SerializeField] List<GameObject> _spawnList = new List<GameObject>();

    public float TapLimitDuration => _tapLimitDuration;

    //public Unit PlayerUnitPrefab => _playerUnitPrefab;
    //public Transform PlayerUnitSpawnLocation => _playerUnitSpawnLocation;
    //public UnitSpawner UnitSpawner => _unitSpawner;
    public TouchManager Touch => _touch;

    private void Update()
    {
        _timeCooldown += Time.deltaTime;
        if (_timeCooldown >= SpawnCooldown)
        {
            Spawn();
            _timeCooldown = 0;
        }
    }

    public static Vector3 GetRandomSpawnPositionFromLine
    (Transform startLoc, Transform endLoc)
    {
        float randomXPos = UnityEngine.Random.Range
            (startLoc.position.x, endLoc.position.x);
        float randomYPos = UnityEngine.Random.Range
            (startLoc.position.y, endLoc.position.y);
        float randomZPos = UnityEngine.Random.Range
            (startLoc.position.z, endLoc.position.z);

        return new Vector3(randomXPos, randomYPos, randomZPos);
    }

    public static GameObject GetRandomSpawn(List<GameObject> spawnList)
    {
        int randomIndex = UnityEngine.Random.Range(0, spawnList.Count);
        return spawnList[randomIndex];
    }

    public void Spawn()
    {
        if (_minPoint == null || _maxPoint == null) { return; }
        if (_spawnList.Count == 0 || _spawnList == null) { return; }

        Vector3 randomSpawnPoint =
            GetRandomSpawnPositionFromLine
            (_minPoint, _maxPoint);
        GameObject randomSpawnObject = GetRandomSpawn(_spawnList);
        Instantiate(randomSpawnObject, randomSpawnPoint, transform.rotation);

        if(SpawnCooldown > .1f)
        {
            SpawnCooldown -= .02f;
        }
        else
        {
            SpawnCooldown = .1f;
        }
    }

    public void WinFeedback()
    {
        if(_winSound != null)
        {
            AudioHelper.PlayClip2D(_winSound, 1f);
        }
       
    }

    public void LoseFeedback()
    {
        if (_loseSound != null)
        {
            AudioHelper.PlayClip2D(_loseSound, 1f);
        }
        
    }

    public void GameplayState()
    {
        _gameplayState.GetComponent<Text>().text = "STATE: Game Setup";
    }

    public void LoadSave()
    {
        _loadSave.GetComponent<Text>().text = "Load Save Data";
    }

    public void SpawnUnits()
    {
        _spawnUnits.GetComponent<Text>().text = "Spawn Units";
    }

    public void Gameplay()
    {
        _gameplay.GetComponent<Text>().text = "STATE: Game Play";
    }

    public void PlayerInputs()
    {
        _playerInputs.GetComponent<Text>().text = "Listen for Player Inputs";
    }

    public void PlayerHUD()
    {
        _playerHUD.GetComponent<Text>().text = "Display Player HUD";
    }
}
