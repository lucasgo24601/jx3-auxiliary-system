using System;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using DotNet.Framework.Common.Algorithm;

namespace JX3_AuxiliarySystem.ImageLearnSystem {
    public class DatabaseSystem {
        public OleDbConnection Database = new OleDbConnection ();
        public OleDbCommand SQLCommand = new OleDbCommand ();
        public DataSet SQLDataSet = new DataSet ();

        public DatabaseSystem () { }

        public void DBSetPart (string DBPart) {
            Database = new OleDbConnection (@"Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" + DBPart + ";");
            SQLCommand = new OleDbCommand ();
        }
        public bool DBOpen () {
            try {
                if (Database.State == ConnectionState.Closed)
                    Database.Open ();

                SQLCommand.Connection = Database;
                return true;
            } catch (Exception ex) {
                Trace.WriteLine ("When open ： " + ex.Message);
            }
            return false;
        }
        public bool DBClose () {
            try {
                if (Database.State == ConnectionState.Open)
                    Database.Close ();
                return true;
            } catch (Exception ex) {
                Trace.WriteLine (ex.Message);
            }
            return false;
        }

        public DataSet SendCommand (string Command) {
            // 回傳DataSet，讓使用者可以自行查看SQL語法後的結果
            SQLDataSet = new DataSet ();
            SQLCommand.Connection = Database;
            SQLCommand.CommandText = Command;
            OleDbDataAdapter adapter = new OleDbDataAdapter (SQLCommand);
            adapter.Fill (SQLDataSet);

            return SQLDataSet;
        }

        public string GetCode (string Code_Image, string TableName) {
            // https://zh.wikipedia.org/wiki/%E8%90%8A%E6%96%87%E6%96%AF%E5%9D%A6%E8%B7%9D%E9%9B%A2
            // 使用字符串相似度算法，來達成影像處理演算法功能

            SortedList DecodeList = new SortedList ();
            LevenshteinDistance Levenshtein = new LevenshteinDistance ();

            try {
                DataTable DTable = new DataTable ();
                switch (TableName) {
                    case "Timer":
                        DTable = SendCommand ("select * from TimerCodes").Tables[0];
                        break;
                    case "HP":
                        DTable = SendCommand ("select * from HPCodes").Tables[0];
                        break;

                    case "喊話":
                        DTable = SendCommand ("select * from 喊話中文 where CodeValue = " + Code_Image).Tables[0];
                        break;

                    case "科舉":
                        DTable = SendCommand ("select 文字 from 科舉中文 where CodeValue = '" + Code_Image + "'").Tables[0];
                        break;
                    case "題庫":
                        DTable = SendCommand ("select 答案 from 科舉題目 where 題目 = '" + Code_Image + "'").Tables[0];
                        break;
                }

                for (int i = 0; i < DTable.Rows.Count; i++) {
                    string Code_Database = "";
                    if (TableName == "科舉" | TableName == "題庫")
                        return DTable.Rows[i][0].ToString ();
                    else {
                        Code_Database = DTable.Rows[i][2].ToString ();
                        decimal parent = Levenshtein.LevenshteinDistancePercent (Code_Database, Code_Image);

                        if (parent > 0.90m) // 相似度>85%
                            if (!DecodeList.ContainsKey (parent))
                                DecodeList.Add (parent, DTable.Rows[i][1]);
                    }
                }

                if (DTable.Rows.Count > 0 & DecodeList.Count > 0)
                    return DecodeList.GetByIndex (DecodeList.Count - 1).ToString ();

                return "Null";
            } catch (Exception ex) {
                Trace.WriteLine ("Decode Error = " + ex.Message);
                return "Null";
            }
        }

        private static int Levenshtein_SameString (String Str1, String Str2) {
            // 此Levenshtein演算法不同於原版於，會先過濾前後段相同字串，來達成快速轉換的效果
            // 缺點是，如果字串前後段相同部分過少，會造成執行效能過低

            // 如若字串前後相同程度居高，可採用此方法

            // 1. 過濾前段相同的字串內容
            int SameStringLength = -1;
            int i = 0;

            while (Str1[i] == Str2[i])
                SameStringLength = i++;

            if (SameStringLength > 0) {
                Str1 = Str1.Substring (SameStringLength);
                Str2 = Str2.Substring (SameStringLength);
            }

            // 2. 過濾後段相同的字串內容

            i = 0;
            SameStringLength = -1;
            while (Str1[Str1.Length - i - 1] == Str2[Str2.Length - i - 1])
                SameStringLength = i++;

            if (SameStringLength > 0) {
                Str1 = Str1.Substring (0, Str1.Length - SameStringLength);
                Str2 = Str2.Substring (0, Str2.Length - SameStringLength);
            }

            if (Str1.Length == 0) return Str2.Length;
            if (Str2.Length == 0) return Str1.Length;

            return Math.Min (Math.Min (Levenshtein_SameString (Str1.Substring (1, Str1.Length), Str2) + 1,
                    Levenshtein_SameString (Str1, Str2.Substring (1, Str2.Length)) + 1),
                Levenshtein_SameString (Str1.Substring (1, Str1.Length), Str2.Substring (1, Str2.Length))) + 1;
        }

    }
}