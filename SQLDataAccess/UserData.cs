using SQLDataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLDataAccess
{
    public class UserData
    {
        private readonly SqlDataAccess db;

        private string database = "dbo.Users";

        public UserData(SqlDataAccess db)
        {
            this.db = db;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = $"SELECT * FROM {database};";
            return db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public async Task<UserModel?> GetUser(int id)
        {
            string sql = $"SELECT * FROM {database} WHERE Id = {id};";
            var v = await db.LoadData<UserModel, dynamic>(sql, new { Id = id });
            return v.FirstOrDefault();
        }

        public Task InsertUser(UserModel user)
        {
            string sql = $@"INSERT INTO {database} (EmailAddress, IsAdmin, PasswordHash) VALUES (@EmailAddress, @IsAdmin, @PasswordHash);";
            return db.SaveData(sql, user);
        }
    }
}
