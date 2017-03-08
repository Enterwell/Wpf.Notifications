using System;

namespace Enterwell.Clients.Wpf.Notifications
{
    /// <summary>
    /// The <see cref="Action"/> extensions.
    /// </summary>
    internal static class ActionExtensions
    {
        /// <summary>
        /// Invokes the specified action after first action was successfully invoked.
        /// </summary>
        /// <typeparam name="T1">The action data type.</typeparam>
        /// <typeparam name="T2">The action data type.</typeparam>
        /// <param name="baseAction">The base action.</param>
        /// <param name="afterBaseAction">The after base action.</param>
        /// <returns>Returns new action that first calls baseAction and then afterBaseAction.</returns>
        public static Action<T1, T2> DoAfter<T1, T2>(this Action<T1, T2> baseAction, Action<T1, T2> afterBaseAction)
        {
            return (data1, data2) =>
            {
                baseAction?.Invoke(data1, data2);
                afterBaseAction?.Invoke(data1, data2);
            };
        }
    }
}