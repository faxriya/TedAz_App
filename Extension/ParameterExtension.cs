using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TedAzApp.Extensions 
{ 
public static partial class Extension
    {

         [AttributeUsage(AttributeTargets.Property,AllowMultiple = false)]
    public class NoUddtColumnAttribute : Attribute
    {
    }
   
        static public IEnumerable<T> ExecuteProcedure<T>(this DbContext context, string query, List<SqlParameter> parameters = null)
      where T : class, new()
        {
            if (!string.IsNullOrWhiteSpace(query))
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    var properties = typeof(T).GetProperties()
                        .Where(p => !p.IsDefined(typeof(NotMappedAttribute), true));

                    command.CommandText = query;
                    command.CommandType = CommandType.StoredProcedure;
                   command.Connection.Open();

                    if (parameters != null && parameters.Count() > 0)
                    {
                        foreach (var parameter in parameters)
                        {
                            var param = command.CreateParameter();
                            param.ParameterName = parameter.ParameterName;
                            param.Value = parameter.Value;
                            param.Direction = parameter.Direction;
                            param.DbType = parameter.DbType;

                            command.Parameters.Add(param);
                        }
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            var entity = new T();
                            foreach (var property in properties)
                            {
                                var value = reader[property.Name];

                                if (value != null && value != DBNull.Value)
                                    property.SetValue(entity, value);
                            }
                            yield return entity;
                        }
                    }
                }
        }
        public static List<SqlParameter> Init()
        {
            return new List<SqlParameter>();
        }
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, int value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Int) { Value = value, Direction = direction });
            return parameters;
        }

        /// <summary>
        /// Nullable Int tipli parameter elave etmek ucun
        /// </summary>
        /// <param name="parameters">Parameterler siyahisi</param>
        /// <param name="parameterName">Parameter adi</param>
        /// <param name="value">Parameter deyeri</param>
        /// <param name="direction">Parameter novu</param>
        /// <returns>parameter siyahisinin son veziyyeti qaytarilir</returns>
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, int? value, ParameterDirection direction = ParameterDirection.Input)
        {
            //eger null deyilse
            if (value.HasValue)
                parameters.Add(parameterName, value.Value, direction);

            return parameters;
        }

        /// <summary>
        /// DateTime tipli parameter elave etmek ucun
        /// </summary>
        /// <param name="parameters">Parameterler siyahisi</param>
        /// <param name="parameterName">Parameter adi</param>
        /// <param name="value">Parameter deyeri</param>
        /// <param name="direction">Parameter novu</param>
        /// <returns>parameter siyahisinin son veziyyeti qaytarilir</returns>
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, DateTime value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.DateTime) { Value = value, Direction = direction });
            return parameters;
        }

        /// <summary>
        /// Nullable DateTime tipli parameter elave etmek ucun
        /// </summary>
        /// <param name="parameters">Parameterler siyahisi</param>
        /// <param name="parameterName">Parameter adi</param>
        /// <param name="value">Parameter deyeri</param>
        /// <param name="direction">Parameter novu</param>
        /// <returns>parameter siyahisinin son veziyyeti qaytarilir</returns>
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, DateTime? value, ParameterDirection direction = ParameterDirection.Input)
        {
            //eger null deyilse
            if (value.HasValue)
                parameters.Add(parameterName, value.Value, direction);

            return parameters;
        }

        /// <summary>
        /// String tipli parameter elave etmek ucun
        /// </summary>
        /// <param name="parameters">Parameterler siyahisi</param>
        /// <param name="parameterName">Parameter adi</param>
        /// <param name="value">Parameter deyeri</param>
        /// <param name="direction">Parameter novu</param>
        /// <returns>parameter siyahisinin son veziyyeti qaytarilir</returns>
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, string value, int size = 4000, ParameterDirection direction = ParameterDirection.Input)
        {
            if (!string.IsNullOrWhiteSpace(value))
                parameters.Add(new SqlParameter(parameterName, SqlDbType.NVarChar, size) { Value = value, Direction = direction });
            return parameters;
        }

        /// <summary>
        /// Int tipli parameter elave etmek ucun
        /// </summary>
        /// <param name="parameters">Parameterler siyahisi</param>
        /// <param name="parameterName">Parameter adi</param>
        /// <param name="value">Parameter deyeri</param>
        /// <param name="direction">Parameter novu</param>
        /// <returns>parameter siyahisinin son veziyyeti qaytarilir</returns>
        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, bool? value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Bit) { Value = value, Direction = direction });
            return parameters;
        }

        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, long value, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.BigInt) { Value = value, Direction = direction });
            return parameters;
        }

        public static List<SqlParameter> Add(this List<SqlParameter> parameters, string parameterName, long? value, ParameterDirection direction = ParameterDirection.Input)
        {
            if (value.HasValue)
                parameters.Add(new SqlParameter(parameterName, SqlDbType.BigInt) { Value = value, Direction = direction });

            return parameters;
        }

        public static List<SqlParameter> Add<T>(this List<SqlParameter> parameters, string parameterName, T value, string valueName, ParameterDirection direction = ParameterDirection.Input)
        {
            parameters.Add(new SqlParameter(parameterName, SqlDbType.Structured) { TypeName = valueName, Value = value, Direction = direction });
            return parameters;
        }

    public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            if (data is null) data = Enumerable.Empty<T>();

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
            {
                if (prop.Attributes.OfType<NoUddtColumnAttribute>().Any()) continue;

                if (prop.Name == "Token") continue;

                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    if (prop.Attributes.OfType<NoUddtColumnAttribute>().Any()) continue;

                    if (prop.Name == "Token") continue;

                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }





    }
}
