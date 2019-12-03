using System;
using System.Collections.Generic;
using Inter2.Models;
using System.Data.SqlClient;

namespace Inter2.Data
{
    public class OrcamentoData : Data
    {
        public Orcamento Create(Orcamento o)
        {
            SqlCommand cmdA = new SqlCommand();
            cmdA.Connection = connection;
            //Puxa o próximo id da tabela e armazena na variável codigo
            cmdA.CommandText = "SELECT MAX(id)+1 AS codigo from Orcamento";
            var codigo = Convert.ToInt32(cmdA.ExecuteScalar());

            if(codigo > 0){
                SqlCommand cmdB = new SqlCommand();
                cmdB.Connection = connection;
                cmdB.CommandText = @"INSERT INTO Orcamento
                                    VALUES(@id, @funcionario_id, @cliente_id, @data, @total)";

                cmdB.Parameters.AddWithValue("@id", codigo);
                cmdB.Parameters.AddWithValue("@funcionario_id", o.Funcionario.IdFuncionario);
                cmdB.Parameters.AddWithValue("@cliente_id", o.Cliente.IdCliente);
                cmdB.Parameters.AddWithValue("@data", DateTime.Now);
                cmdB.Parameters.AddWithValue("@total", 10.00);

                /*cmdB.Parameters.AddWithValue("@id", codigo);
                cmdB.Parameters.AddWithValue("@funcionario_id", 4);
                cmdB.Parameters.AddWithValue("@cliente_id", 6);
                cmdB.Parameters.AddWithValue("@data", DateTime.Now);
                cmdB.Parameters.AddWithValue("@total", 10);*/

                cmdB.ExecuteNonQuery();
            }
            return o;
        }
    }
}