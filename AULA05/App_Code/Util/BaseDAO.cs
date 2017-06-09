using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace Util
{
    /// <summary>
    /// Classe que serve de base para todos os objetos DAO oferencendo recursos abstraidos para manipulaçao de query e transação no banco de dados
    /// Funcional para SQL Server
    /// </summary>
    public class BaseDAO
    {
        protected static string connectionString = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
        private static string _strConexao = ConfigurationManager.ConnectionStrings["Banco"].ConnectionString;
        private static SqlConnection _conn;
        private static SqlCommand _comandoSQL;
        private static SqlTransaction _transacao;

        protected static SqlCommand ComandoSQL
        {
            get
            {
                if (_conn == null)
                {
                    _conn = new SqlConnection(_strConexao);
                    _comandoSQL = new SqlCommand();
                    _comandoSQL.Connection = _conn;
                }
                return _comandoSQL;
            }
            set { _comandoSQL = value; }
        }

        protected static bool AbreConexao(bool transacao)
        {
            try
            {
                if (_conn.State == ConnectionState.Closed)
                    _conn.Open();
                if (transacao)
                {
                    if (_transacao == null)
                    {
                        _transacao = _conn.BeginTransaction();
                        _comandoSQL.Transaction = _transacao;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected static bool FechaConexao()
        {
            try
            {
                if (_conn.State == ConnectionState.Open)
                    _conn.Close();
                _transacao = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void FinalizaTransacao(bool commit)
        {
            if (commit)
                _transacao.Commit();
            else
                _transacao.Rollback();
            FechaConexao();
        }

        /// <summary>
        /// Recomendado para UPDATE e DELETE. Retorna a quantidade de linhas afetadas.
        /// </summary>
        /// <param name="transacao"></param>
        /// <returns></returns>
        protected static int ExecutaComando(bool transacao)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            AbreConexao(transacao);
            try
            {
                retorno = _comandoSQL.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL: " + ex.Message, ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }

        /// <summary>
        /// Recomendado para INSERT com SELECT SCOPE_IDENTITY();. Retorna o valor da primeira coluna da primeira linha.
        /// </summary>
        /// <param name="transacao"></param>
        /// <param name="ultimoCodigo"></param>
        /// <returns></returns>
        protected static int ExecutaScalar(bool transacao, bool insert)
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            int retorno;
            AbreConexao(transacao);
            try
            {
                retorno = Convert.ToInt32(_comandoSQL.ExecuteScalar());
            }
            catch (Exception ex)
            {
                retorno = -1;
                throw new Exception("Erro ao executar o comando SQL: " + ex.Message, ex);
            }
            finally
            {
                if (!transacao)
                    FechaConexao();
            }
            return retorno;
        }

        /// <summary>
        /// Recomendado para SELECT. Retorna um objeto com diversos dados tratados
        /// </summary>
        /// <returns>Objeto DataTable com os dados retornados do banco</returns>
        protected static DataTable ExecutaReader()
        {
            if (_comandoSQL.CommandText.Trim() == string.Empty)
                throw new Exception("Não há instrução SQL a ser executada.");

            AbreConexao(false);
            DataTable dt = new DataTable();
            try
            {
                dt.Load(_comandoSQL.ExecuteReader());
            }
            catch (Exception ex)
            {                
                throw new Exception("Erro ao executar o comando SQL: " + ex.Message, ex);
            }
            finally
            {
                FechaConexao();
            }
            return dt;
        }        

        /// <summary>
        /// Limpa todos os parametros salvos em memoria
        /// </summary>
        protected static void LimpaParametros()
        {
            ComandoSQL.Parameters.Clear();
        }
    }
}