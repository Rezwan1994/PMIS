using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
//using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;
using PMIS.Repository.Interface;
using PMIS.Domain.Common;
//using System.Text.Json;

namespace PMIS.Repository.Implementation
{
    public class CommonServices : ICommonServices
    {
        public QueryPattern AddQuery(string query, Dictionary<string, string> parametes)
        {
            QueryPattern queryPattern = new QueryPattern
            {
                Query = query
            };
            queryPattern.Parametes.Add(parametes);
            return queryPattern;
        }
        public string DataTableToJSON(DataTable table)
        {

            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return JsonConvert.SerializeObject(parentRow);
        }
        public string DataSetToJSON(DataSet ds)
        {
            ArrayList root = new ArrayList();
            List<Dictionary<string, object>> table;
            Dictionary<string, object> data;

            foreach (DataTable dt in ds.Tables)
            {
                table = new List<Dictionary<string, object>>();
                foreach (DataRow dr in dt.Rows)
                {
                    data = new Dictionary<string, object>();
                    foreach (DataColumn col in dt.Columns)
                    {
                        data.Add(col.ColumnName, dr[col]);
                    }
                    table.Add(data);
                }
                root.Add(table);
            }

            return JsonConvert.SerializeObject(root);
        }


        public DataRow GetDataRow(string conString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                using OracleConnection obcon = new OracleConnection(conString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                using OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);
                    }
                }
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                DataRow row = dataTable.Rows[0];
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet GetDataSet(string connString, string query, Dictionary<string, string> param)
        {
            try
            {
                using OracleConnection obcon = new OracleConnection(connString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                using OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);
                    }
                }
                DataSet dataSet = new DataSet();
                dataAdapter.Fill(dataSet);
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataTable GetDataTable(string conString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                using OracleConnection obcon = new OracleConnection(conString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                using OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);


                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);
                    }
                }
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetMaxNumNonParaQuery<T>(string conneString, string query)
        {
            try
            {
                var data = "";
                using OracleConnection obcon = new OracleConnection(conneString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                obcon.Open();
                using OracleCommand cmd = new OracleCommand(query, obcon);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = Convert.ToString(reader[0]);

                    }
                    reader.Close();
                    obcon.Close();
                }
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public T GetMaximumNumber<T>(string conneString, string query, Dictionary<string, string> param)
        {
            try
            {
                var data = "";
                using OracleConnection conn = new OracleConnection(conneString);
                conn.UseHourOffsetForUnsupportedTimezone = true;

                conn.Open();
                using OracleDataAdapter da = new OracleDataAdapter();
                using OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;

                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        cmd.Parameters.Add(item.Key, item.Value);
                    }
                }
                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = Convert.ToString(reader[0]);

                    }
                    reader.Close();
                    conn.Close();
                }
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }

        public bool SaveChanges(string conString, List<QueryPattern> queryPatterns)
        {
            try
            {
                using (OracleConnection obcon = new OracleConnection(conString))
                {
                    obcon.UseHourOffsetForUnsupportedTimezone = true;

                    obcon.Open();
                    OracleTransaction transaction;
                    // Start a local transaction.
                    //System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.ReadCommitted;
                    transaction = obcon.BeginTransaction();
                    try
                    {
                        //foreach (var data)
                        using OracleCommand cmd = obcon.CreateCommand();
                        cmd.Transaction = transaction;
                        foreach (var data in queryPatterns)
                        {
                            cmd.CommandText = data.Query;
                            //string query = cmd.CommandText;
                            if (data.Parametes.Count > 0 && data.Parametes != null)
                            {
                                cmd.Parameters.Clear();
                                foreach (var parameter in data.Parametes)
                                {
                                    foreach (var item in parameter)
                                    {
                                        cmd.Parameters.Add(item.Key, item.Value);
                                    }
                                }
                            }
                            //foreach (SqlParameter p in cmd.Parameters)
                            //{
                            //    query = query.Replace(p.ParameterName, p.Value.ToString());
                            //}
                            cmd.ExecuteNonQuery();
                        }
                        // Attempt to commit the transaction.
                        transaction.Commit();
                        obcon.Close();
                    }
                    catch (Exception ex)
                    {
                        // Attempt to roll back the transaction.
                        try
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        catch (Exception ex2)
                        {
                            throw ex2;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// this method return dictionary of parameter, default parameter is KeyValuePair<"@param1","com_code">, others parameter start name @param2 and end parameter name defendend you. how many parameter pass in array parameter 
        /// </summary>
        /// <param name="values">array of parameter values</param>
        /// <returns></returns>
        public Dictionary<string, string> AddParameter(string[] values)
        {
            var parameter = new Dictionary<string, string>();
            int i = 1;
            if (values.Length > 0)
            {
                foreach (var data in values)
                {
                    parameter.Add($":param{i}", data);
                    i++;
                }
            }
            return parameter;
        }
        public async Task<T> ProcedureCallAsyn<T>(string connString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                List<int> outputParam = new List<int>();
                List<string> result = new List<string>();
                using OracleConnection conn = new OracleConnection(connString);
                conn.UseHourOffsetForUnsupportedTimezone = true;

                conn.Open();
                OracleTransaction transaction;

                transaction = conn.BeginTransaction();
                try
                {
                    using OracleDataAdapter da = new OracleDataAdapter();
                    using OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;
                    if (param != null && param.Count > 0)
                    {
                        int i = 0;
                        foreach (var item in param)
                        {
                            if (item.Value == "RefCursor")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue; ;

                            }
                            else if (item.Value == "Int32")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.Int32);
                                cmd.Parameters[i].Direction = ParameterDirection.ReturnValue;
                                outputParam.Add(i);
                            }
                            else if (item.Value == "Varchar2")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.Varchar2, 32767).Direction = ParameterDirection.ReturnValue;
                                outputParam.Add(i);

                            }
                            else
                            {
                                cmd.Parameters.Add(item.Key, item.Value);

                            }
                            i++;
                        }
                    }
                    await Task.Run(() => cmd.ExecuteNonQuery());

                    foreach (var item in outputParam)
                    {
                        if (item > 0 && cmd.Parameters[item].Direction == ParameterDirection.ReturnValue)
                        {
                            result.Add(cmd.Parameters[item].Value.ToString());
                        }
                    }
                    if (result.Count == 0)
                    {
                        result.Add("1");
                    }
                    transaction.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;

                }
                return (T)Convert.ChangeType(System.Text.Json.JsonSerializer.Serialize(result), typeof(T));
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }


        }
        public async Task<T> PreExecuteProcedureCallAsyn<T>(string connString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                List<int> outputParam = new List<int>();
                List<string> result = new List<string>();
                using OracleConnection conn = new OracleConnection(connString);
                conn.UseHourOffsetForUnsupportedTimezone = true;

                conn.Open();
                OracleTransaction transaction;

                transaction = conn.BeginTransaction();
                try
                {
                    using OracleDataAdapter da = new OracleDataAdapter();
                    using OracleCommand cmd = new OracleCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    cmd.CommandTimeout = 0;
                    if (param != null && param.Count > 0)
                    {
                        int i = 0;
                        foreach (var item in param)
                        {
                            if (item.Value == "RefCursor")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.RefCursor).Direction = ParameterDirection.ReturnValue; ;

                            }
                            else if (item.Value == "Int32")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.Int32);
                                cmd.Parameters[i].Direction = ParameterDirection.ReturnValue;
                                outputParam.Add(i);
                            }
                            else if (item.Value == "Varchar2")
                            {
                                cmd.Parameters.Add(item.Key, OracleDbType.Varchar2, 32767).Direction = ParameterDirection.ReturnValue;
                                outputParam.Add(i);

                            }
                            else
                            {
                                cmd.Parameters.Add(item.Key, item.Value);

                            }
                            i++;
                        }
                    }

                    await Task.Run(() => cmd.ExecuteNonQuery());


                    foreach (var item in outputParam)
                    {
                        if (item > 0 && cmd.Parameters[item].Direction == ParameterDirection.ReturnValue)
                        {
                            result.Add(cmd.Parameters[item].Value.ToString());
                        }
                    }
                    if (result.Count == 0)
                    {
                        result.Add("1");
                    }
                    transaction.Commit();
                    conn.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex;

                }

                return (T)Convert.ChangeType(System.Text.Json.JsonSerializer.Serialize(result), typeof(T));
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }


        }
        public async Task<DataTable> GetDataTableAsyn(string connString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                OracleConnection obcon = new OracleConnection(connString)
                {
                    UseHourOffsetForUnsupportedTimezone = true
                };

                OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        if (item.Value == "RefCursor")
                        {
                            dataAdapter.SelectCommand.Parameters.Add(":param1", OracleDbType.RefCursor);
                            dataAdapter.SelectCommand.Parameters[0].Direction = ParameterDirection.ReturnValue;


                        }
                        else
                        {
                            dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);

                        }
                    }
                }
                DataTable dt = new DataTable();
                await Task.Run(() => dataAdapter.Fill(dt));
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataSet> GetDataSetAsyn(string connString, string query, Dictionary<string, string> param)
        {
            try
            {
                using OracleConnection obcon = new OracleConnection(connString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                using OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);
                    }
                }
                DataSet dataSet = new DataSet();
                await Task.Run(() => dataAdapter.Fill(dataSet));
                return dataSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<DataRow> GetDataRowAsyn(string connString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                using OracleConnection obcon = new OracleConnection(connString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                using OracleDataAdapter dataAdapter = new OracleDataAdapter(query, obcon);
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        dataAdapter.SelectCommand.Parameters.Add(item.Key, item.Value);
                    }
                }
                DataTable dataTable = new DataTable();
                await Task.Run(() => dataAdapter.Fill(dataTable));

                DataRow row = dataTable.Rows[0];
                return row;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<bool> SaveChangesAsyn(string connString, List<QueryPattern> queryPatterns)
        {
            try
            {
                using (OracleConnection obcon = new OracleConnection(connString))
                {
                    obcon.UseHourOffsetForUnsupportedTimezone = true;

                    obcon.Open();
                    OracleTransaction transaction;
                    // Start a local transaction.
                    //System.Data.IsolationLevel isolationLevel = System.Data.IsolationLevel.ReadCommitted;

                    transaction = obcon.BeginTransaction();
                    try
                    {
                        //foreach (var data)
                        using OracleCommand cmd = obcon.CreateCommand();
                        cmd.Transaction = transaction;
                        cmd.BindByName = true;
                        foreach (var data in queryPatterns)
                        {
                            cmd.CommandText = data.Query;
                            if (data.Parametes.Count > 0 && data.Parametes != null)
                            {
                                cmd.Parameters.Clear();
                                foreach (var parameter in data.Parametes)
                                {
                                    foreach (var item in parameter)
                                    {
                                        cmd.Parameters.Add(item.Key, item.Value);
                                    }
                                }
                            }
                            await Task.Run(() => cmd.ExecuteNonQuery());
                        }
                        // Attempt to commit the transaction.
                        transaction.Commit();
                        obcon.Close();
                    }
                    catch (Exception ex)
                    {
                        // Attempt to roll back the transaction.
                        try
                        {
                            transaction.Rollback();
                            throw ex;
                        }
                        catch (Exception ex2)
                        {
                            throw ex2;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<T> GetMaxNumNonParaQueryAsyn<T>(string connString, string query)
        {
            try
            {
                var data = "";
                using OracleConnection obcon = new OracleConnection(connString);
                obcon.UseHourOffsetForUnsupportedTimezone = true;

                obcon.Open();
                using OracleCommand cmd = new OracleCommand(query, obcon);
                OracleDataReader reader = await Task.Run(() => cmd.ExecuteReader());
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = Convert.ToString(reader[0]);

                    }
                    reader.Close();
                    obcon.Close();
                }
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<T> GetMaximumNumberAsyn<T>(string connString, string query, Dictionary<string, string> param)
        {


            try
            {
                var data = "";
                using OracleConnection conn = new OracleConnection(connString);
                conn.UseHourOffsetForUnsupportedTimezone = true;

                conn.Open();
                using OracleDataAdapter da = new OracleDataAdapter();
                using OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = 0;
                if (param != null && param.Count > 0)
                {
                    foreach (var item in param)
                    {
                        cmd.Parameters.Add(item.Key, item.Value);
                    }
                }
                OracleDataReader reader = await Task.Run(() => cmd.ExecuteReader());

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        data = Convert.ToString(reader[0]);

                    }
                    reader.Close();
                    conn.Close();
                }
                return (T)Convert.ChangeType(data, typeof(T));
            }
            catch (Exception ex)
            {
                return (T)Convert.ChangeType(ex.Message, typeof(T));
            }
        }
        public string ReturnExtension(string fileExtension)
        {
            switch (fileExtension)
            {
                case ".txt":
                    return "text/plain";
                case ".doc":
                    return "application/msword";
                case ".pdf":
                    return "application/pdf";
                case ".xls":
                    return "application/vnd.ms-excel";
                case ".gif":
                    return "image/gif";
                case ".png":
                    return "image/png";
                case ".jpg":
                case "jpeg":
                    return "image/jpeg";
                case ".bmp":
                    return "image/bmp";
                case ".wav":
                    return "audio/wav";
                case ".ppt":
                    return "application/vnd.ms-powerpoint";
                case ".dwg":
                    return "image/vnd.dwg";
                default:
                    return "application/octet-stream";
            }
        }

        public bool DataSave(string connString, string query, Dictionary<string, string> param = null)
        {
            try
            {
                using (OracleConnection obcon = new OracleConnection(connString))
                {
                    obcon.UseHourOffsetForUnsupportedTimezone = true;

                    obcon.Open();
                    using OracleCommand cmd = obcon.CreateCommand();
                    cmd.CommandText = query;
                    if (param.Count > 0 && param != null)
                    {
                        foreach (var item in param)
                        {
                            cmd.Parameters.Add(item.Key, item.Value);
                        }
                    }
                    cmd.ExecuteNonQuery();
                    obcon.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }


        public string Encrypt(string pstrText)
        {

            string pstrEncrKey = "SquareIformatixLtd";

            return Encrypt(pstrText, pstrEncrKey);
        }


        public string Decrypt(string pstrText)
        {
            pstrText = pstrText.Replace(" ", "+");
            string pstrDecrKey = "SquareIformatixLtd";

            return Decrypt(pstrText, pstrDecrKey);

        }


        public string Encrypt(string plainText, string passPhrase)
        {
            int DerivationIterations = 1000;
            int Keysize = 128;
            // Salt and IV is randomly generated each time, but is preprended to encrypted cipher text
            // so that the same Salt and IV values can be used when decrypting.  
            var saltStringBytes = Generate256BitsOfRandomEntropy();
            var ivStringBytes = Generate256BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream())
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                // Create the final bytes as a concatenation of the random salt bytes, the random iv bytes and the cipher bytes.
                                var cipherTextBytes = saltStringBytes;
                                cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
                                cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Convert.ToBase64String(cipherTextBytes);
                            }
                        }
                    }
                }
            }
        }

        public string Decrypt(string cipherText, string passPhrase)
        {
            int DerivationIterations = 1000;
            int Keysize = 128;
            // Get the complete stream of bytes that represent:
            // [32 bytes of Salt] + [32 bytes of IV] + [n bytes of CipherText]
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            // Get the saltbytes by extracting the first 32 bytes from the supplied cipherText bytes.
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            // Get the IV bytes by extracting the next 32 bytes from the supplied cipherText bytes.
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            // Get the actual cipher text bytes by removing the first 64 bytes from the cipherText string.
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8 * 2).Take(cipherTextBytesWithSaltAndIv.Length - Keysize / 8 * 2).ToArray();

            using (var password = new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            {
                var keyBytes = password.GetBytes(Keysize / 8);
                using (var symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.BlockSize = 128;
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.Padding = PaddingMode.PKCS7;
                    using (var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
                    {
                        using (var memoryStream = new MemoryStream(cipherTextBytes))
                        {
                            using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                            {
                                var plainTextBytes = new byte[cipherTextBytes.Length];
                                var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                memoryStream.Close();
                                cryptoStream.Close();
                                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                            }
                        }
                    }
                }
            }
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            var randomBytes = new byte[16]; // 32 Bytes will give us 256 bits.
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                // Fill the array with cryptographically secure random bytes.
                rngCsp.GetBytes(randomBytes);
            }
            return randomBytes;
        }
        public List<T> ConvertDataTableToList<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();
            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        public DataTable ListToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties by using reflection   
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names  
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {

                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }
}
