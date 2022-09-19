using AnimalsCollection.Models;
using System.Data.SqlClient;

namespace AnimalsCollection.Data
{
    internal class CreatureDAO
    {
        private string connectionString = @"Data Source=(localdb)\Local;Initial Catalog=CreatureDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; 
        // Perform all operations on the database. get all, create, delete, get one, search, etc.

        public List<CreatureModel> FetchAll()
        {
            List<CreatureModel> returnList = new List<CreatureModel>();
            //access database

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.creatures";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a new creature object, add to returning list.
                        CreatureModel creature = new CreatureModel();
                        creature.Id = reader.GetInt32(0);
                        creature.Name = reader.GetString(1);
                        creature.Description = reader.GetString(2);
                        creature.Age = reader.GetInt32(3);
                        creature.Strength = reader.GetInt32(4);
                        creature.Speed = reader.GetInt32(5);
                        creature.Intelligence = reader.GetInt32(6);
                        creature.Level = reader.GetInt32(7);

                        returnList.Add(creature);
                    }
                }
                connection.Close();

            }

            return returnList;
        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.Creatures WHERE Id= @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 100).Value = id;


                connection.Open();

                int deletedId = command.ExecuteNonQuery();



                return deletedId;
            }
        }

        public CreatureModel FetchOne(int id)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.creatures WHERE Id = @id";
                //associate @id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                CreatureModel creature = new CreatureModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        // create a new creature object, add to returning list.
                        creature.Id = reader.GetInt32(0);
                        creature.Name = reader.GetString(1);
                        creature.Description = reader.GetString(2);
                        creature.Age = reader.GetInt32(3);
                        creature.Strength = reader.GetInt32(4);
                        creature.Speed = reader.GetInt32(5);
                        creature.Intelligence = reader.GetInt32(6);
                        creature.Level = reader.GetInt32(7);

                        
                    }
                }

                connection.Close();

                return creature;

            }

        }

        // create new
        public int CreateOrUpdate(CreatureModel creatureModel)
        {
            
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "";
                
                if (creatureModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.Creatures Values(@Name, @Description, @Age, @Strength, @Speed, @Intelligence, @Level)";

                }
                else
                {
                    sqlQuery = "UPDATE dbo.Creatures SET Name = @Name, Description = @Description, Age = @Age, Strength = @Strength, Speed = @Speed, Intelligence = @Intelligence, Level = @Level WHERE Id = @Id";


                }


                SqlCommand command = new SqlCommand(sqlQuery, connection);
                
                command.Parameters.Add("@Id", System.Data.SqlDbType.Int, 100).Value = creatureModel.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.VarChar, 100).Value = creatureModel.Name;
                command.Parameters.Add("@Description", System.Data.SqlDbType.VarChar, 1000).Value = creatureModel.Description;
                command.Parameters.Add("@Age", System.Data.SqlDbType.Int).Value = creatureModel.Age;
                command.Parameters.Add("@Strength", System.Data.SqlDbType.Int).Value = creatureModel.Strength;
                command.Parameters.Add("@Speed", System.Data.SqlDbType.Int).Value = creatureModel.Speed;
                command.Parameters.Add("@Intelligence", System.Data.SqlDbType.Int).Value = creatureModel.Intelligence;
                command.Parameters.Add("@Level", System.Data.SqlDbType.Int).Value = creatureModel.Level;

                connection.Open();

                int newId = command.ExecuteNonQuery();
                                
                

                return newId;
            }

        }


        // delete one
        

        // search for name

        // search description


    }
}