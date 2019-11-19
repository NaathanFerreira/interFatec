using System.Data.SqlClient;
using Inter2.Models;
using System.Collections.Generic;
using System;


namespace Inter2.Data
{
    public class ClienteData : Data
    {
        public List<Cliente> Read()
        {
            List<Cliente> cliente = new List<Cliente>();
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "SELECT * FROM v_clientes";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Cliente c = new Cliente();
                c.Id = (int)reader["id"];
                c.Nome = (string)reader["nome"];
                c.Email = (string)reader["email"];
                c.Cpf = (string)reader["cpf"];
                c.Endereco = (string)reader["endereco"];

                cliente.Add(c);
            }

            return cliente;
        }
        //---------------------------------------------------
        public void Create(Cliente e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"exec cadastroCliente
                                @nome, @email, @cpf, @endereco";
            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@cpf", e.Cpf);
            cmd.Parameters.AddWithValue("@endereco", e.Endereco);
            cmd.ExecuteNonQuery();
        }
        //----------------------------------------------------
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Clientes WHERE id_Pessoa = @id
                                    DELETE FROM Pessoas WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
         public Cliente Read(int id)
         {
             Cliente c = null;

             SqlCommand cmd = new SqlCommand();
             cmd.Connection = connection;
             cmd.CommandText = @"SELECT * FROM v_clientes WHERE id = id";
             cmd.Parameters.AddWithValue("@id", id);

             SqlDataReader reader = cmd.ExecuteReader();
             if(reader.Read())
             {
                 c = new Cliente{
                     Id = (int)reader["id"],
                     Nome = (string)reader["nome"],
                     Email = (string)reader["email"],
                     Cpf = (string)reader["cpf"],
                     Endereco = (string)reader["endereco"]
                 };
             }
             return c;
         }
         //------------------------------------------
         public void Update(Cliente e)
         {
             SqlCommand cmd = new SqlCommand();
             cmd.Connection = connection;
             cmd.CommandText = @"UPDATE Pessoas SET nome = @nome, email = @email, cpf = @cpf WHERE id = @id
                                UPDATE Clientes SET endereco = @endereco WHERE id_Pessoa = @id";
            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@cpf", e.Cpf);
            cmd.Parameters.AddWithValue("@endereco", e.Endereco);
            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.ExecuteNonQuery();
         }
    }
}