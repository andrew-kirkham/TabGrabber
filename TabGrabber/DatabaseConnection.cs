using System.Data.SQLite;

namespace TabGrabber {
    class DatabaseConnection {
        private SQLiteConnection dbConn;

        public DatabaseConnection() {
            dbConn = new SQLiteConnection();
        }

        public void ExecuteCommand(string query) {
            dbConn.Open();
            SQLiteCommand command = dbConn.CreateCommand();
            command.CommandText = query;
            command.ExecuteNonQuery();
            dbConn.Close();
        }

        public SQLiteDataReader ExecuteQuery(string query) {
            dbConn.Open();
            SQLiteCommand command = dbConn.CreateCommand();
            command.CommandText = query;
            SQLiteDataReader reader = command.ExecuteReader();
            dbConn.Close();
            return reader;
        }
    }
}
