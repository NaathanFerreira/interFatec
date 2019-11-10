using System.Data.SqlClient;
using Inter2.Models;
using System.Collections.Generic;
using System;

namespace Inter2.Data
{
    public class ProdutoData : IDisposable
    {
        private SqlConnection connection;

        public ProdutoData()
        {
            string strConn = @"Data Source=localhost;
                                Initial Catalog=OrcamentoDigital;
                                Integrated Security=true";

            connection = new SqlConnection(strConn);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }

        public List<Produto> Read()
        {
            List<Produto> lista = new List<Produto>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM Produtos";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Produto p = new Produto();
                p.Id = (int)reader["Id"];
                p.Nome = (string)reader["nome"];
                p.Preco = (decimal)reader["preco"];
                p.Descricao = (string)reader["descricao"];
                p.QuantidadeEstoque = (int)reader["quantidade_estoque"];

                lista.Add(p);
            }

            return lista;
        }

        public void Create(Produto e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"INSERT INTO Produtos
                                VALUES(@nome, @preco, @descricao, @quantidade_estoque)";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@preco", e.Preco);
            cmd.Parameters.AddWithValue("@descricao", e.Descricao);
            cmd.Parameters.AddWithValue("@quantidade_estoque", e.QuantidadeEstoque);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Produtos WHERE Id=@id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }

        public Produto Read(int id)
        {
            Produto p = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM Produtos
                                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read())
            {
                p = new Produto{
                    Id = (int)reader["Id"],
                    Nome = (string)reader["nome"],
                    Preco = (decimal)reader["preco"],
                    Descricao = (string)reader["descricao"],
                    QuantidadeEstoque = (int)reader["quantidade_estoque"]                   
                };
            }

            return p;
        }

        public void Update(Produto e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Produtos 
                                SET nome = @nome , preco = @preco , descricao = @desc , 
                                quantidade_estoque = @quantidade_estoque
                                WHERE Id = @id";

            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@preco", e.Preco);
            cmd.Parameters.AddWithValue("@desc", e.Descricao);
            cmd.Parameters.AddWithValue("@quantidade_estoque", e.QuantidadeEstoque);
            cmd.Parameters.AddWithValue("@id", e.Id);

            cmd.ExecuteNonQuery();
        }
    }
}