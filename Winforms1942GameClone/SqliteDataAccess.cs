using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using Dapper;

namespace Winforms1942GameClone
{
    public class SqliteDataAccess
    {
        public static List<ScoreModel> LoadScores()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                //order by Score.Score desc
                var output = cnn.Query<ScoreModel>("select * from Score order by Score desc",new DynamicParameters());
                return output.ToList();
            }
        }

        public static void SaveScore(ScoreModel score)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Score(Username,Score) values (@Username,@Score)", score);
            }
        }

        public static string LoadConnectionString(string connectionString = "Default")
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings[connectionString].ConnectionString; 
        }
    }
}
