using UnityEngine;

namespace Projects.Scripts.Core
{
    /// <summary>
    ///     シングルトンなMonoBehaviour
    /// </summary>
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour
        where T : SingletonMonoBehaviour<T>, IAltoManager
    {
        private static Option<T> _instance;

        protected bool IsInitialized { get; private set; }

        /// <summary>
        ///     DontDestroyOnLoadにするか
        /// </summary>
        protected virtual bool IsDontDestroy => true;

        /// <summary>
        ///     シングルトンインスタンス
        /// </summary>
        public static T Instance
        {
            get
            {
                if (!Application.isPlaying)
                {
                    Debug.LogWarning("シングルトンは実行時のみ有効です。");
                    return null;
                }

                if (_instance.HasValue) return _instance.Value;

                // 既存のインスタンスを探す
                _instance.Value = FindObjectOfType<T>();

                if (_instance.HasValue)
                {
                    if (_instance.Value.IsInitialized) return _instance.Value;

                    // 初期化
                    _instance.Value.OnInitialize();
                    _instance.Value.IsInitialized = true;
                    return _instance.Value;
                }

                // コンポーネントを新たに作成
                var obj = new GameObject(typeof(T).Name);
                var component = obj.AddComponent<T>();
                // 初期化
                component.OnInitialize();
                component.IsInitialized = true;
                _instance.Value = component;

                return _instance.Value;
            }
        }

        private void Awake()
        {
            if (IsDontDestroy) DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            _instance = default;
        }
    }
}