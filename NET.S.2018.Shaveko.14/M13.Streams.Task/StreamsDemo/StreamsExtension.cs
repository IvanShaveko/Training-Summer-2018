using System;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx

    public static class StreamsExtension
    {

        #region Public members

        #region TODO: Implement by byte copy logic using class FileStream as a backing store stream .

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream fileRead = File.OpenRead(sourcePath))
            {
                using (FileStream fileWrite = File.OpenWrite(destinationPath))
                {
                    int b;
                    while ((b =fileRead.ReadByte()) != -1)
                    {
                        fileWrite.WriteByte((byte) b);
                    }

                    return (int) fileWrite.Length;
                }
            }
            
        }

        #endregion

        #region TODO: Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);
            byte[] data;
            using (StreamReader streamReader = new StreamReader(sourcePath))
            {
                var bytes = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
                using (MemoryStream stream = new MemoryStream(bytes))
                {
                    data = stream.ToArray();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(destinationPath))
            {
                var bytes = Encoding.UTF8.GetChars(data);
                foreach (var item in bytes)
                {
                    streamWriter.Write(item);
                }

                return bytes.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            using (FileStream fileRead = File.OpenRead(sourcePath))
            {
                using (FileStream fileWrite = File.OpenWrite(destinationPath))
                {
                    fileRead.CopyTo(fileWrite);
                    return (int) fileWrite.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] data;
            using (StreamReader fileReader = new StreamReader(sourcePath))
            {
                var bytes = Encoding.UTF8.GetBytes(fileReader.ReadToEnd());
                using (MemoryStream fileMemory = new MemoryStream(bytes))
                {
                    data = fileMemory.ToArray();
                }
            }

            using (StreamWriter fileWriter = new StreamWriter(destinationPath))
            {
                var bytes = Encoding.UTF8.GetChars(data);
                fileWriter.Write(bytes);
                return bytes.Length;
            }
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            byte[] data = File.ReadAllBytes(sourcePath);
            using (FileStream fileWrite = File.Open(destinationPath, FileMode.Create))
            {
                using (BufferedStream stream = new BufferedStream(fileWrite))
                {
                    stream.Write(data, 0, data.Length);
                    return (int) stream.Length;
                }
            }
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            string[] strings = File.ReadAllLines(sourcePath);
            File.WriteAllLines(destinationPath, strings);
            return strings.Length;
        }

        #endregion

        #region TODO: Implement content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath, string destinationPath)
        {
            InputValidation(sourcePath, destinationPath);

            if (sourcePath == destinationPath)
            {
                return true;
            }

            using (FileStream sourth = new FileStream(sourcePath, FileMode.Open))
            {
                using (FileStream destination = new FileStream(destinationPath, FileMode.Open)) 
                {
                    if (sourth.Length != destination.Length)
                    {
                        return false;
                    }

                    for (int i = 0; i < sourth.Length; i++)
                    {
                        if (sourth.ReadByte() != destination.ReadByte())
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
            if (sourcePath == null || destinationPath == null)
            {
                throw new ArgumentException($"Parameters can not be null");
            }

            if (!File.Exists(sourcePath))
            {
                throw new FileNotFoundException($"{nameof(sourcePath)} does not exist");
            }

            if (!File.Exists(destinationPath))
            {
                throw new FileNotFoundException($"{nameof(destinationPath)} is not exist");
            }
        }

        #endregion

        #endregion

    }
}
