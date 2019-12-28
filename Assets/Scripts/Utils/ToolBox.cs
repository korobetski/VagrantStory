using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace Utils
{
    public class ToolBox
    {
        public static uint GetNumPositiveBits(int bnumt)
        {
            uint inc = 0;
            BitArray b = new BitArray(new int[] { bnumt });
            if (bnumt != 0)
            {
                for (var j = 0; j < b.Length; j++)
                {
                    if (b.Get(j))
                    {
                        inc++;
                    }
                }
            }
            return inc;
        }
        public static string GetGameObjectPath(GameObject obj, string baseName)
        {
            string path = obj.name;
            while (obj.transform.parent != null)
            {
                obj = obj.transform.parent.gameObject;
                path = obj.name + "/" + path;
            }
            path = path.Remove(0, baseName.Length + 1);
            return path;
        }
        public static GameObject findBoneIn(string boneName, GameObject obj)
        {
            foreach (Transform child in obj.transform)
            {
                if (child.name == boneName)
                {
                    return child.gameObject;
                }
                else
                {
                    GameObject littleChild = findBoneIn(boneName, child.gameObject);
                    if (littleChild != null)
                    {
                        return littleChild;
                    }
                }
            }

            return null;
        }

        internal static Color[] ExpandColors(Color[] colors, ushort? count = null)
        {
            Color[] newColors = new Color[colors.Length * 2];
            for (var i = 0; i < colors.Length; i++)
            {
                newColors[i * 2] = colors[i];
                if (i < colors.Length - 1)
                {
                    newColors[i * 2 + 1] = Color.Lerp(colors[i], colors[i + 1], 0.5f);
                }
                else
                {
                    newColors[i * 2 + 1] = Color.Lerp(colors[i], Color.black, 0.5f);
                }
            }

            if (count != null)
            {
                if (newColors.Length < count)
                {
                    newColors = ExpandColors(newColors, count);
                }
            }

            return newColors;
        }

        public static Quaternion quatFromAxisAnle(Vector3 axis, float angle)
        {
            Quaternion q = new Quaternion(axis.x * Mathf.Sin(angle / 2), axis.y * Mathf.Sin(angle / 2), axis.z * Mathf.Sin(angle / 2), Mathf.Cos(angle / 2));
            q.Normalize();
            return q;
        }
        public static float rot13toRad(int angle)
        {
            float f = Mathf.PI / 4096;
            return (float)(f * angle);
        }
        public static byte[] EndianSwitcher(byte[] bytes)
        {
            Array.Reverse(bytes);
            return bytes;
        }
        public static void DirExNorCreate(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
        public static Color32 BitColorConverter(ushort rawColor)
        {
            if (rawColor == 0)
            {
                return new Color32(0, 0, 0, 0);
            }
            else
            {
                int a = (rawColor & 0x8000) >> 15;
                int b = (rawColor & 0x7C00) >> 10;
                int g = (rawColor & 0x03E0) >> 5;
                int r = (rawColor & 0x001F);
                if (r == 0 && g == 0 && b == 0)
                {
                    if ((rawColor & 0x8000) == 0)
                    {
                        // black, and the alpha bit is NOT set
                        a = (byte)0; // totally transparent
                    }
                    else
                    {
                        // black, and the alpha bit IS set
                        a = (byte)255; // totally opaque
                    }
                }
                else
                {
                    if ((rawColor & 0x8000) == 0)
                    {
                        // some color, and the alpha bit is NOT set
                        a = (byte)255; // totally opaque
                    }
                    else
                    {
                        // some color, and the alpha bit IS set
                        a = (byte)250; // some variance of transparency
                    }
                }

                Color32 color = new Color32((byte)(r * 8), (byte)(g * 8), (byte)(b * 8), (byte)a);
                return color;
            }
        }


        internal static void DestroyChildren(GameObject gameObject, bool coroutine = false)
        {
            int cc = gameObject.transform.childCount;
            if (cc > 0)
            {
                foreach (Transform child in gameObject.transform)
                {
#if UNITY_EDITOR
                    if (coroutine)
                    {
                        UnityEditor.EditorApplication.delayCall += () =>
                        {
                            GameObject.DestroyImmediate(child.gameObject);
                        };
                    }
                    else
                    {
                        GameObject.DestroyImmediate(child.gameObject);
                    }
#else
                    GameObject.Destroy(child.gameObject);
#endif

                }

            }
        }

        public static void WriteJSON(string path, string data)
        {
            File.WriteAllText(path, data);
        }
    }
}
