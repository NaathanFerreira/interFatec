using System.Collections.Generic;
using Inter2.Models;
using System.Data.SqlClient;

namespace Inter2.Data
{
    public class FuncionarioData : Data
    {
        public List<Funcionario> Read()
        {
            List<Funcionario> listaFunc = new List<Funcionario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "SELECT * FROM v_funcionarios";

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Funcionario func = new Funcionario();
                func.IdFuncionario = (int)reader["id"];
                func.Nome = (string)reader["nome"];
                func.Email = (string)reader["email"];
                func.Cpf = (string)reader["cpf"];
                func.AnosExperiencia = (int)reader["anosExperiencia"];

                listaFunc.Add(func);
            }
            return listaFunc;
        }
        //-------------------------------------------------------------------

        public void Create(Funcionario e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"exec cadastroFuncionario
                                @nome, @email, @cpf, @anosExperiencia";
            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@cpf", e.Cpf);
            cmd.Parameters.AddWithValue("@anosExperiencia", e.AnosExperiencia);

            cmd.ExecuteNonQuery();
        }

        //------------------------------------------------------
        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"DELETE FROM Funcionarios WHERE id_Pessoas = @id
                                DELETE FROM Pessoas WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        public Funcionario Read(int id)
        {
            Funcionario f = null;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"SELECT * FROM v_funcionarios
                                WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                f = new Funcionario{
                    IdFuncionario = (int)reader["id"],
                    Nome = (string)reader["nome"],
                    Email = (string)reader["email"],
                    Cpf = (string)reader["cpf"],
                    AnosExperiencia = (int)reader["anosExperiencia"]
                };
            }
            return f;
        }
        //--------------------------------------------------------------------

        public void Update(Funcionario e)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = @"UPDATE Pessoas SET nome = @nome, email = @email, cpf = @cpf WHERE id = @id
                                UPDATE Funcionarios SET anosExperiencia = @anosExperiencia WHERE id_Pessoas = @id";
            cmd.Parameters.AddWithValue("@nome", e.Nome);
            cmd.Parameters.AddWithValue("@email", e.Email);
            cmd.Parameters.AddWithValue("@cpf", e.Cpf);
            cmd.Parameters.AddWithValue("@anosExperiencia", e.AnosExperiencia);
            cmd.Parameters.AddWithValue("@id", e.IdFuncionario);
            cmd.ExecuteNonQuery();
        }
    }
}