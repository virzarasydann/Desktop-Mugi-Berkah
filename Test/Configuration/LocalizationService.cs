using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace TugasBesar.App.Configuration
{
    public static class LocalizationService
    {
        // Dictionary ini bertugas menggantikan fungsi file .resx
        private static Dictionary<string, string> _translations = new Dictionary<string, string>();

        public static void SetLanguage(string langCode)
        {
            _translations.Clear();

            // Mencari file .po di folder aplikasi berjalan (bin/Debug/Languages)
            string filePath = Path.Combine(Application.StartupPath, "Languages", $"{langCode}.po");

            if (!File.Exists(filePath))
            {
                return; // Jika file tidak ditemukan, hentikan proses
            }

            // Logika membaca file .po secara manual
            string[] lines = File.ReadAllLines(filePath);
            string currentMsgId = null;

            foreach (string line in lines)
            {
                string trimmed = line.Trim();

                // Menangkap baris msgid (Key)
                if (trimmed.StartsWith("msgid \""))
                {
                    int start = trimmed.IndexOf('"') + 1;
                    int end = trimmed.LastIndexOf('"');
                    currentMsgId = trimmed.Substring(start, end - start);
                }
                // Menangkap baris msgstr (Value) dan memasukkannya ke Dictionary
                else if (trimmed.StartsWith("msgstr \"") && currentMsgId != null)
                {
                    int start = trimmed.IndexOf('"') + 1;
                    int end = trimmed.LastIndexOf('"');
                    string msgStr = trimmed.Substring(start, end - start);

                    _translations[currentMsgId] = msgStr;
                    currentMsgId = null; // Reset untuk kata berikutnya
                }
            }
        }

        public static string GetString(string key)
        {
            // Cek apakah kata tersebut ada di kamus Dictionary kita
            if (_translations.TryGetValue(key, out string value))
            {
                return value;
            }
            // Jika tidak ada, kembalikan key-nya agar kita tahu apa yang belum diterjemahkan
            return key;
        }
    }
}