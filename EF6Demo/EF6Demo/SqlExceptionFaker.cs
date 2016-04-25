using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace EF6Demo
{
    public static class SqlExceptionFaker
    {
        private static SqlException _error10053;

        public static SqlException Error10053
        {
            get
            {
                if (_error10053 == null)
                {
                    _error10053 = Generate(SqlExceptionNumber.TransportLevelReceiving);
                }
                return _error10053;
            }

        }
        public enum SqlExceptionNumber : int
        {
            TimeoutExpired = -2,
            EncryptionNotSupported = 20,
            LoginError = 64,
            ConnectionInitialization = 233,
            TransportLevelReceiving = 10053,
            TransportLevelSending = 10054,
            EstablishingConnection = 10060,
            ProcessingRequest = 40143,
            ServiceBusy = 40501,
            DatabaseOrServerNotAvailable = 40613
        }

        public static SqlException Generate(SqlExceptionNumber errorNumber)
        {
            return SqlExceptionFaker.Generate((int)errorNumber);
        }

        public static SqlException Generate(int errorNumber)
        {
            var ex = (SqlException)FormatterServices.GetUninitializedObject(typeof(SqlException));

            var errors = GenerateSqlErrorCollection(errorNumber);
            SetPrivateFieldValue(ex, "_errors", errors);
            return ex;
        }

        private static SqlErrorCollection GenerateSqlErrorCollection(int errorNumber)
        {
            var t = typeof(SqlErrorCollection);
            var col = (SqlErrorCollection)FormatterServices.GetUninitializedObject(t);
            SetPrivateFieldValue(col, "errors", new ArrayList());
            var sqlError = GenerateSqlError(errorNumber);
            var method = t.GetMethod(
              "Add",
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            method.Invoke(col, new object[] { sqlError });
            return col;
        }

        private static SqlError GenerateSqlError(int errorNumber)
        {
            var sqlError = (SqlError)FormatterServices.GetUninitializedObject(typeof(SqlError));

            SetPrivateFieldValue(sqlError, "number", errorNumber);
            SetPrivateFieldValue(sqlError, "message", errorNumber.ToString());
            SetPrivateFieldValue(sqlError, "procedure", string.Empty);
            SetPrivateFieldValue(sqlError, "server", string.Empty);
            SetPrivateFieldValue(sqlError, "source", string.Empty);
            SetPrivateFieldValue(sqlError, "win32ErrorCode", errorNumber);

            return sqlError;
        }

        private static void SetPrivateFieldValue(object obj, string field, object val)
        {
            var member = obj.GetType().GetField(
              field,
              System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance
              );
            member.SetValue(obj, val);
        }
    }
}