using System;
using System.Collections.Generic;
using Npgsql;
using Users.Models;

namespace Users.Services {

	public static class UserService {
		const string connString = "Host=localhost;Database=cubestocks";

	    static void UserServiceProvider() {
			var conn = new NpgsqlConnection(connString);
			conn.Open();

			// Retrieve all rows
			var cmd = new NpgsqlCommand("SELECT * FROM client", conn);
			var reader = cmd.ExecuteReader();
			while (reader.Read()) {
				Console.WriteLine(reader.GetString(0));
			}
	    }

		public static List<User> GetAll() {
			var conn = new NpgsqlConnection(connString);
			conn.Open();

			// Retrieve all rows
			var userList = new List<User>();
			var cmd = new NpgsqlCommand("SELECT * FROM users", conn);
			var reader = cmd.ExecuteReader();
			while (reader.Read()) {
				userList.Add(new User {
					Id = Convert.ToInt32(reader["id"]),
					Username = reader["username"].ToString(),
					Lastname = reader["lastname"].ToString(),
					Firstname = reader["firstname"].ToString(),
					Password = reader["password"].ToString()
				});
			}
			return userList;
		}
	}
}
