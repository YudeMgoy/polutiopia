using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

namespace Hypertonic.GridPlacement
{
    /// <summary>
    /// A utility class to aid with async operations
    /// </summary>
    public class AsyncHelpers : MonoBehaviour
    {
        /// <summary>
        /// An async function that awaits Unity's fixed update
        /// </summary>
        /// <returns></returns>
        public async Task WaitForFixedUpdate()
        {
            bool finished = false;

            StartCoroutine(WaitForFixedUpdateCoroutine(() => finished = true));

            while (!finished)
            {
                await Task.Delay(1);
            }
        }

        private IEnumerator WaitForFixedUpdateCoroutine(Action finshedCallback)
        {
            yield return new WaitForFixedUpdate();

            finshedCallback?.Invoke();
        }

        /// <summary>
        /// An async function that wait's for the end of the frame
        /// </summary>
        /// <returns></returns>
        public async Task WaitForEndOfFrame()
        {
            bool finished = false;

            StartCoroutine(WaitForEndOfFrame(() => finished = true));

            while (!finished)
            {
                await Task.Delay(1);
            }
        }

        private IEnumerator WaitForEndOfFrame(Action finshedCallback)
        {
            yield return new WaitForEndOfFrame();

            finshedCallback?.Invoke();
        }
    }
}
