using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int _coinCount;
    [SerializeField] private Text _cointext;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        } 
    }

    public void AddCoin()
    {
        _coinCount++;
        _cointext.text = _coinCount.ToString();
    }
}
