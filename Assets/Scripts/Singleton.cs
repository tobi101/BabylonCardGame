using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;
    public static T instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError(typeof(T).ToString() + " is missing.");
            }
            return _instance;
        }
    }

    void OnEnable()
    {
        if (_instance != null)
        {
            Debug.LogWarning("Second instance of " + typeof(T) + " created. Automatic self-destruct triggered.");
            Destroy(_instance);
        }
        _instance = this as T;
        Init();
    }

    void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
        }
    }

    public virtual void Init() { }
}