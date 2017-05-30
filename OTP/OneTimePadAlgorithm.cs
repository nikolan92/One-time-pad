using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTP
{
    public static class OneTimePadAlgorithm
    {
        public static void encrypt(byte[] bytesForEncrypt, string key, out byte[] newBytes, out int newByteLength)
        {
            if(bytesForEncrypt == null)
            {
                newBytes = null;
                newByteLength = 0;
                return;
            }
            key = key.ToUpper();

            byte[] keyInByte = System.Text.Encoding.ASCII.GetBytes(key);
            int keyLenght = keyInByte.Length;

            for (int j = 0; j < keyLenght; j++)
                keyInByte[j] = (byte)(keyInByte[j] - 65);// kljuc su velika slova i to tako da imaju vrednost a=0000 0000,b=0000 0001,c= 0000 0010 ...
                                                         // tako da kad se odradi xor kljuca i teksta za kodiranje idalje prikazuju slova kao izlaz a ne neki drugi simboli

            byte[] buffer = new byte[bytesForEncrypt.Length];

            newByteLength = 0;

            for (int i = 0; i < bytesForEncrypt.Length; i++)
            {
                int tmp;
                if (bytesForEncrypt[i] >= 97 && bytesForEncrypt[i] <= 122)//mala slova
                {
                    tmp = bytesForEncrypt[i] - 97;// - 32 da se povecaju slova u ascii i - 65 da se dobije to da je kodni jezik azbuke a= 000,b= 001, c=010 ...
                    tmp = tmp + keyInByte[newByteLength % keyLenght];
                    if (tmp > 25)
                    {
                        tmp  = tmp - 26;
                    }
                    buffer[newByteLength] = (byte)(tmp + 65);
                    newByteLength++;
                }
                else if (bytesForEncrypt[i] >= 65 && bytesForEncrypt[i] <= 90)//velika slova
                {
                    tmp = bytesForEncrypt[i] - 65;//ista prica kao gore samo sto ovde ne moramo da oduzimamo 32 zato sto su slova vec velika
                    tmp = tmp + keyInByte[newByteLength % keyLenght];
                    if (tmp > 25)
                    {
                        tmp = tmp - 26;
                    }
                    buffer[newByteLength] = (byte)(tmp + 65);
                    newByteLength++;
                }
            }
  
            newBytes = buffer;
        }
        public static void decrypt(byte[] bytesForDecrypt, string key, out byte[] newBytes, out int newByteLength)
        {
            key = key.ToUpper();

            byte[] keyInByte = System.Text.Encoding.ASCII.GetBytes(key);
            int keyLenght = keyInByte.Length;

            for (int j = 0; j < keyLenght; j++)
                keyInByte[j] = (byte)(keyInByte[j] - 65);// kljuc su velika slova i to tako da imaju vrednost a=0000 0000,b=0000 0001,c= 0000 0010 ...
                // tako da kad se odradi xor kljuca i teksta za kodiranje idalje prikazuju slova kao izlaz a ne neki drugi simboli

            byte[] buffer = new byte[bytesForDecrypt.Length];

            newByteLength = 0;

            for (int i = 0; i < bytesForDecrypt.Length; i++)
            {
                if (bytesForDecrypt[i] >= 65 && bytesForDecrypt[i] <= 90)//velika slova
                {
                    int tmp;
                    tmp = bytesForDecrypt[i] - 65;//ista prica kao gore samo sto ovde ne moramo da oduzimamo 32 zato sto su slova vec velika
                    tmp = tmp - keyInByte[newByteLength % keyLenght];
                    if (tmp < 0)
                    {
                        tmp += 26;
                    }
                    buffer[newByteLength] = (byte)(tmp + 65);
                    newByteLength++;
                }
            }

            newBytes = buffer;
        }

        public static void upperCaseAndRemoveOtherCharacters(byte[] bytes, out byte[] newBytes, out int newByteLength)
        {
            byte[] buffer = new byte[bytes.Length];

            newByteLength = 0;

            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] >= 97 && bytes[i] <= 122)
                {
                    buffer[newByteLength] = (byte)(bytes[i] - 32);
                    newByteLength++;
                }
                else if (bytes[i] >= 65 && bytes[i] <= 90)
                {
                    buffer[newByteLength] = bytes[i];
                    newByteLength++;
                }
            }

            newBytes = buffer;
        }
    }
}
