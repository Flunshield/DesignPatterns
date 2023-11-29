using MySql.Data.MySqlClient;

public class MySqlConnectionSingleton
{
    private static MySqlConnectionSingleton instance;
    private MySqlConnection connection;

    private string connectionString = "Server=127.0.0.1;Port=3306;User ID=root;Password=;";

    // Utilisez un verrou pour assurer que l'instanciation est thread-safe
    private static readonly object lockObject = new object();

    public MySqlConnectionSingleton()
    {
        connection = new MySqlConnection(connectionString);
    }


    // Méthode pour récupérer l'instance unique de la classe
    public static MySqlConnectionSingleton Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new MySqlConnectionSingleton();
                }
                return instance;
            }
        }
    }

    // Méthode pour ouvrir la connexion à la base de données
    public MySqlConnection GetConnection()
    {
        if (connection.State != System.Data.ConnectionState.Open)
        {
            connection.Open();
        }
        return connection;
    }

    // Méthode pour fermer la connexion à la base de données
    public void CloseConnection()
    {
        if (connection.State != System.Data.ConnectionState.Closed)
        {
            connection.Close();
        }
    }
}
