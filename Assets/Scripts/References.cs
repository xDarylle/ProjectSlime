using UnityEngine;

public class References : MonoBehaviour
{
    static References instance;
    public GameController gameController;
    public Player Player;
    public Spawner Spawner;

    private void Awake()
    {
        instance = this;
    }

    public static GameController gamecontroller { get { return instance.gameController; } }
    public static Player player { get { return instance.Player; } }

    public static Spawner spawner { get { return instance.Spawner; } }
}
