using System;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Toolkit
{
    /// <summary>
    /// Toolkit for UI to check if an content should being update due to modification.
    /// </summary>
    /// <typeparam name="T">The type of content</typeparam>
    public class UpdatableContent<T>
    {
        /// <summary>
        /// The concurrently value.
        /// </summary>
        public T Value { get; private set; }
        
        /// <summary>
        /// The newest value which has not being apply to <see cref="Value"/>.
        /// </summary>
        public T CachedValue { get; private set; }

        public event Action<T> UpdateCallback; 

        // todo: Add cancellation token to avoid multiply call in same frame.
        
        public UpdatableContent(T val = default)
        {
            Value = val;
        }

        /// <summary>
        /// Update content with new value was given.
        /// </summary>
        public void Update(PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.PreUpdate)
        {
            Update(Value, playerLoopTiming);
        }

        /// <summary>
        /// Update content which it was self-updated.
        /// </summary>
        public async void Update(T content, PlayerLoopTiming playerLoopTiming = PlayerLoopTiming.PreUpdate)
        {
            CachedValue = content;
            await UniTask.Yield(playerLoopTiming);
            Value = CachedValue;
            try { UpdateCallback?.Invoke(Value); }
            catch (Exception e) { Debug.LogError(e); }
        }
    }
}