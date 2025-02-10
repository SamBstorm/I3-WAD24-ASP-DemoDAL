using Common.Repositories;
using DAL.Entities;
using DAL.Mappers;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class CommentService : BaseService, ICommentRepository<Comment>
    {
        public CommentService(IConfiguration config) : base(config, "Main-DB") { }

        public void Delete(Guid comment_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Comment_Delete";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(comment_id), comment_id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<Comment> GetByUserId(Guid user_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Comment_GetByUserId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(user_id), user_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToComment();
                        }
                    }
                }
            }
        }

        public Comment Get(Guid comment_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [Comment_Id], [Title], [Content], [Concern], [CreatedBy], [CreatedAt], [Note] FROM [Comment] WHERE [Comment_Id] = @comment_id";
                    command.Parameters.AddWithValue(nameof(comment_id), comment_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToComment();
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException(nameof(comment_id));
                        }
                    }
                }
            }
        }

        public IEnumerable<Comment> GetByCocktailId(Guid cocktail_id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Comment_GetByCocktailId";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(cocktail_id), cocktail_id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToComment();
                        }
                    }
                }
            }
        }

        public Guid Insert(Comment comment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Comment_Insert";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(Comment.Title), comment.Title);
                    command.Parameters.AddWithValue(nameof(Comment.Content), comment.Content );
                    command.Parameters.AddWithValue("cocktail_id", comment.Concern);
                    command.Parameters.AddWithValue("user_id", (object?)comment.CreatedBy ?? DBNull.Value);
                    command.Parameters.AddWithValue(nameof(Comment.Note), (object?) comment.Note ?? DBNull.Value);
                    connection.Open();
                    return (Guid)command.ExecuteScalar();
                }
            }
        }

        public void Update(Guid comment_id, Comment comment)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_Comment_Update";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue(nameof(comment_id), comment_id);
                    command.Parameters.AddWithValue(nameof(Comment.Title), comment.Title);
                    command.Parameters.AddWithValue(nameof(Comment.Content), comment.Content);
                    command.Parameters.AddWithValue(nameof(Comment.Note), (object?)comment.Note ?? DBNull.Value);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
