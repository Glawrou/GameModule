using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace naa
{
    public static class Matha
    {
        public static T Random<T>(T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }

        public static T Random<T>(List<T> list)
        {
            return Random(list.ToArray());
        }

        public static void Alignment(Transform[] transforms, Vector3 center, float indent)
        {
            if (transforms.Length <= 0)
            {
                Debug.LogError("Mathfa >> Alignment() >> transforms is empty");
                return;
            }

            var startPosX = -(transforms.Length / 2) * indent;
            for (int i = 0; i < transforms.Length; i++)
            {
                var t = transforms[i].transform;
                t.position = new Vector3(
                    startPosX + (indent * i),
                    center.y,
                    center.z);
            }
        }

        public static Transform[] ConvertToTransformArray(MonoBehaviour[] gameObjects)
        {
            return gameObjects.Select(o => o.transform).ToArray();
        }

        public static Vector3 Clamp(Vector3 vector, float min, float max)
        {
            return new Vector3(
                Mathf.Clamp(vector.x, min, max),
                Mathf.Clamp(vector.y, min, max),
                Mathf.Clamp(vector.z, min, max)
                );
        }
    }
}
