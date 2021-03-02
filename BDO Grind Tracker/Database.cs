using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace BDO_Grind_Tracker
{
    public class Database
    {
        private static string db = "grind_log.sqlite";
        private static string connection = "Data Source =" + db + ";Version=3;";
        public static class Zone
        {
            public static string table { get { return "zones"; } }
            public static string id { get { return "zone_id"; } }
            public static string name { get { return "zone_name"; } }
        }
        public static class Item
        {
            public static string table { get { return "items"; } }
            public static string id  { get { return "item_id"; } }
            public static string name { get { return "item_name"; } }
            public static string category  { get { return "category"; } }
            public static string marketValue { get { return "market_value";  } }
            public static string vendorValue { get { return "vendor_value";  } }
        }
        public static string[] itemCat = new string[]
        {
            "Trash",
            "Equipment",
            "Crafting Mat",
            "Scroll Piece",
            "Alchemy Stone",
            "Crystal",
            "Consumable"
        };
        public static class ZoneDrops
        {
            public static string table { get { return "zone_drops"; } }
            public static string id { get { return "zone_drop_id"; } }
            public static string zoneID { get { return "zone_id"; } }
            public static string item { get { return "item_id"; } }
        }
        public static class RotationDrops
        {
            public static string table { get { return "rotation_drops"; } }
            public static string id { get { return "rotation_drop_id"; } }
            public static string name { get { return "rotation_id"; } }
            public static string item { get { return "item_id"; } }
        }
        public static class Rotation
        {
            public static string table { get { return "rotations"; } }
            public static string id { get { return "rotation_id"; } }
            public static string name { get { return "rotation_name"; } }
            public static string zone { get { return "zone_id"; } }
        }
        public static class Session
        {
            public static string table { get { return "sessions"; } }
            public static string id { get { return "session_id"; } }
            public static string date { get { return "session_date"; } }
            public static string duration { get { return "duration"; } }
            public static string rotation { get { return "rotation_id"; } }
            public static string ap { get { return "ap"; } }
            public static string scroll { get { return "scroll"; } }
            public static string agris { get { return "agris"; } }
        }
        public static class Amounts
        {
            public static string table { get { return "counts"; } }
            public static string id { get { return "count_id"; } }
            public static string session { get { return "session_id"; } }
            public static string item { get { return "item_id"; } }
            public static string amount { get { return "count"; } }
        }
        public static class Player
        {
            public static string table { get { return "players"; } }
            public static string id { get { return "player_id"; } }
            public static string name { get { return "player_name"; } }
            public static string ap { get { return "ap"; } }
            public static string kutum { get { return "kutum"; } }
        }

        public Database()
        {
            if (!File.Exists(db))
            {
                SQLiteConnection.CreateFile(db);
            }

            SQLiteConnection conn = CreateConnect();
            CreateTables(conn);
            conn.Close();
        }

        static SQLiteConnection CreateConnect()
        {
            SQLiteConnection conn;
            conn = new SQLiteConnection(connection);

            try
            {
                conn.Open();
            }
            catch
            {

            }
            return conn;
        }

        private void CreateTables(SQLiteConnection conn)
        {
            Queue<string> TableCommands = new Queue<string>();
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Zone.table
                + "(" + Zone.id + " integer PRIMARY KEY AUTOINCREMENT,"
                + Zone.name + " varchar, "
                + "UNIQUE(zone_name));");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Item.table 
                + "(" + Item.id +" integer PRIMARY KEY AUTOINCREMENT,"
                + Item.name + " string, "
                + Item.category + " integer, "
                + Item.marketValue + " integer, "
                + Item.vendorValue + " integer, "
                + "UNIQUE(item_name));");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + ZoneDrops.table
                + "(" + ZoneDrops.id + " integer PRIMARY KEY AUTOINCREMENT, "
                + ZoneDrops.zoneID + " integer, "
                + ZoneDrops.item + " integer, "
                + "UNIQUE(item_id, zone_id), "
                + "CONSTRAINT fk_zones FOREIGN KEY (zone_id) REFERENCES zones(zone_id) ON DELETE CASCADE,"
                + "CONSTRAINT fk_item FOREIGN KEY (item_id) REFERENCES items(item_id) ON DELETE CASCADE);");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + RotationDrops.table
                + "(" + RotationDrops.id + " integer PRIMARY KEY AUTOINCREMENT,"
                + RotationDrops.name + " integer,"
                + RotationDrops.item + " integer, "
                + "UNIQUE(rotation_id,item_id), "
                + "CONSTRAINT fk_items FOREIGN KEY (item_id) REFERENCES items(item_id) ON DELETE CASCADE, "
                + "CONSTRAINT fk_rotations FOREIGN KEY (rotation_id) REFERENCES rotations(rotation_id) ON DELETE CASCADE);");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Rotation.table
                + "(" + Rotation.id + " integer PRIMARY KEY AUTOINCREMENT,"
                + Rotation.name + " string," 
                + Rotation.zone + " integer,"
                + "CONSTRAINT fk_zones FOREIGN KEY (zone_id) REFERENCES zones(zone_id) ON DELETE CASCADE);");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Session.table
                + "(" + Session.id + " integer PRIMARY KEY AUTOINCREMENT, "
                + Session.date + " nvarchar(16), "
                + Session.duration + " nvarchar(10), "
                + Session.rotation + " integer, "
                + Session.ap + " integer, "
                + Session.scroll + " bool, "
                + Session.agris + " bool,"
                + "CONSTRAINT fk_rotations FOREIGN KEY (rotation_id) REFERENCES rotations(rotation_id) ON DELETE CASCADE);");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Amounts.table
                + "(" + Amounts.id + " integer PRIMARY KEY AUTOINCREMENT,"
                + Amounts.session + " integer,"
                + Amounts.item + " integer,"
                + Amounts.amount + " integer,"
                + "CONSTRAINT fk_sessions FOREIGN KEY (session_id) REFERENCES sessions(session_id) ON DELETE CASCADE,"
                + "CONSTRAINT fk_items FOREIGN KEY (item_id) REFERENCES items(item_id) ON DELETE CASCADE);");
            TableCommands.Enqueue("CREATE TABLE IF NOT EXISTS " + Player.table
                + " (" + Player.id + " integer PRIMARY KEY AUTOINCREMENT,"
                + Player.name + " string,"
                + Player.ap + " integer,"
                + Player.kutum + " boolean, "
                + "UNIQUE(player_name));");
            
            while(TableCommands.Count > 0)
            {
                Write(TableCommands.Dequeue());
            }
        }

        public void Clear()
        {
            FileInfo fi = new FileInfo(db);

            try
            {
                if (fi.Exists)
                {
                    SQLiteConnection conn = new SQLiteConnection(connection);
                    conn.Close();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    fi.Delete();
                }
            }
            catch(Exception ex)
            {
                fi.Delete();
            }
        }

        public string Write(string sql)
        {
            FileInfo fi = new FileInfo(db);
            string lastID = "";

            try
            {
                if (fi.Exists) 
                {
                    SQLiteConnection conn = CreateConnect();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    command.ExecuteNonQuery();
                    lastID = conn.LastInsertRowId.ToString();
                    conn.Close(); 
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(sql + '\n' + ex.ToString());
            }

            return lastID;
        }

        public DataTable Read(string sql)
        {
            DataTable data = new DataTable();
            FileInfo fi = new FileInfo(db);

            try
            {
                if (fi.Exists)
                {
                    SQLiteConnection conn = CreateConnect();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
                    adapter.Fill(data);
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(sql +'\n' + ex.ToString());
            }

            return data;
        }
    }
}
