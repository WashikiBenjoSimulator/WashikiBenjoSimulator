namespace Projects.Scripts.Core
{
    /// <summary>
    ///     値を持っているか不明な値を作成
    /// </summary>
    /// <typeparam name="T">持つ値の型</typeparam>
    public struct Option<T>
    {
        private T _value;

        /// <summary>
        ///     値
        /// </summary>
        public T Value
        {
            get => _value;
            set
            {
                if (value != null)
                {
                    _value = value;
                    HasValue = true;
                }
                else
                {
                    HasValue = false;
                }
            }
        }

        /// <summary>
        ///     値を持っているか
        /// </summary>
        public bool HasValue;
    }
}