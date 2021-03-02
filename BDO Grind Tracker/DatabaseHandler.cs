using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Diagnostics;

namespace BDO_Grind_Tracker
{
    class PlayerData
    {
        public string name;
        public string ap;
        public string kutum;
    }
    class ItemData
    {
        public string name;
        public string category;
        public string market;
        public string vendor;

        public ItemData()
        {
            name = "";
            category = "";
            market = "";
            vendor = "";
        }

        public ItemData(string itemName)
        {
            name = itemName;
            category = "";
            market = "";
            vendor = "";
        }
    }
    class Drop
    {
        public string name;
        public string amount;
        public string market;
        public string vendor;
    }
    class Session
    {
        public string date;
        public string duration;
        public TreeNode rotation;
        public string ap;
        public string scroll;
        public string agris;

        public Session()
        {
            date = DateTime.Today.ToString("yyyy-M-d HH:mm");
        }
    }
    static class DatabaseHandler
    {
        private static Database database;
        public static void Load()
        {
            database = new Database();
        }
        public static void Delete()
        {
            database.Clear();
            return;
        }

        internal static string FetchSingleData(string sql)
        {
            DataTable id = database.Read(sql);
            return id.Rows[0][0].ToString();
        }
        internal static DataTable FetchData(string sql)
        {
            DataTable data = new DataTable();
            data = database.Read(sql);

            if (data == null)
                return null;

            return data;
        }
        private static void ViewQuery(string sql)
        {
            System.Windows.Forms.MessageBox.Show(sql);
        }

        //----Zone Data---
        internal static string GetLocationID(TreeNode node)
        {
            string sql = "";

            if (node.Parent == null)
                sql = "SELECT zone_id FROM zones WHERE zone_name = '" + node.Text + "';";
            else
                sql = "SELECT rotation_id FROM rotations WHERE rotation_name = '" + node.Text + "' AND zone_id = " + GetLocationID(node.Parent) + ";";

            return FetchSingleData(sql);
        }
        internal static void AddLocation(TreeNode node)
        {
            string sql = "";

            if(node.Parent == null)
                sql = "INSERT OR IGNORE INTO zones(zone_name) VALUES ('" + node.Text + "'); " +
                    "INSERT OR IGNORE INTO rotations(rotation_name,zone_id) SELECT 'Main', zone_id FROM zones z WHERE z.zone_name = '"+ node.Text +"';";
            else
                sql = "INSERT OR IGNORE INTO rotations(rotation_name, zone_id) VALUES ('" + node.Text + "', " + GetLocationID(node.Parent) + ");";

            //ViewQuery(sql);
            database.Write(sql);
        }
        internal static TreeNode[] LoadLocations(TreeNode node = null)
        {
            List<TreeNode> locations = new List<TreeNode>();
            List<string> spots = new List<string>();
            string sql = "";

            if (node == null)
            {
                sql = "SELECT zone_name FROM zones;";
            }
            else
            {
                sql = "SELECT rotation_name FROM rotations WHERE zone_id = " + GetLocationID(node) + ";";
            }

            DataTable data = FetchData(sql);

            foreach (DataRow row in data.Rows)
            {
                TreeNode temp = new TreeNode(row[0].ToString());

                if (node == null)
                {
                    temp.Nodes.AddRange(LoadLocations(temp));
                }

                locations.Add(temp);
            }

            return locations.ToArray();
        }
        internal static List<Drop> GetDrops(TreeNode node)
        {
            List<Drop> drops = new List<Drop>();
            List<string> items = BuildItemList(node);
            
            foreach (string item in items)
            {
                Drop drop = new Drop();
                drop.name = item;
                drop.amount = GetAmountForItem(item, node);
                drop.market = GetMarketPrice(item);
                drop.vendor = GetVendorPrice(item);
                drops.Add(drop);
            }

            return drops;
        }
        internal static void AddDrop(string item, string zone)
        {
            string sql = "INSERT OR IGNORE INTO zone_drops(zone_id,item_id) SELECT " + GetLocationID(new TreeNode(zone)) + ", item_id FROM items WHERE items.item_name = '"+item+"';";
            database.Write(sql);
        }
        private static string GetVendorPrice(string item)
        {
            string sql = "SELECT vendor_value FROM items WHERE item_name = '" + item + "';";
            return FetchSingleData(sql);
        }
        private static string GetMarketPrice(string item)
        {
            string sql = "SELECT market_value FROM items WHERE item_name = '" + item + "';";
            return FetchSingleData(sql);
        }
        private static List<string> BuildItemList(TreeNode node)
        {
            string sql = "SELECT i.item_name,i.category FROM items i " +
                "JOIN zone_drops zd ON i.item_id = zd.item_id " +
                "WHERE zd.zone_id = ";

            DataTable data = new DataTable();

            if(node.Parent == null)
                sql += GetLocationID(node) + " ORDER BY i.category ASC;";
            else
                sql += GetLocationID(node.Parent) + " EXCEPT " +
                    "SELECT i.item_name,i.category FROM items i " +
                    "JOIN rotation_drops rd ON i.item_id = rd.item_id " +
                    "WHERE rd.rotation_id = "+GetLocationID(node)+" " +
                    "ORDER BY i.category ASC;";
            
            data = FetchData(sql);
            List<string> items = new List<string>();

            foreach(DataRow row in data.Rows)
            {
                items.Add(row[0].ToString());
            }

            return items;
        }
        internal static void DeleteLocation(TreeNode node)
        {
            string sql = "";

            if(node.Parent == null)
            {
                while(node.Nodes.Count > 0)
                {
                    DeleteLocation(node.FirstNode);
                    node.FirstNode.Remove();
                }

                sql = "PRAGMA foreign_keys=ON; DELETE FROM zones WHERE zone_id = " + GetLocationID(node) + ";";
            }
            else
            {
                sql = "PRAGMA foreign_keys=ON; DELETE FROM rotations WHERE rotation_id = " + GetLocationID(node) + ";";
            }

            database.Write(sql);
        }
        internal static List<Drop> GetAllDrops()
        {
            string sql = "SELECT item_name FROM items;";

            DataTable data = FetchData(sql);

            List<Drop> drops = new List<Drop>();

            foreach (DataRow row in data.Rows)
            {
                string item = row[0].ToString();

                Drop drop = new Drop();
                drop.name = item;
                drop.amount = GetTotalAmountForItem(item);
                drop.market = GetMarketPrice(item);
                drop.vendor = GetVendorPrice(item);
                drops.Add(drop);
            }

            return drops;
        }
        internal static string GetAmountForItem(string item, TreeNode node)
        {
            string sql = "SELECT SUM(count) FROM sessions s "
                + "JOIN rotations r ON r.rotation_id = s.rotation_id "
                + "JOIN counts c ON c.session_id = s.session_id "
                + "JOIN items i ON i.item_id = c.item_id "
                + "WHERE i.item_name = '" + item + "' AND zone_id = ";

            if (node.Parent == null)
                sql += GetLocationID(node) + ";";
            else
                sql += GetLocationID(node.Parent) + " AND r.rotation_id = " + GetLocationID(node) + ";";

            return FetchSingleData(sql);
        }
        internal static string GetTotalAmountForItem(string item)
        {
            string sql = "SELECT SUM(c.count) FROM counts c JOIN items i ON c.item_id = i.item_id WHERE i.item_name = '"+item+"';";
            return FetchSingleData(sql);
        }
        //---Player Data---
        public static void saveCharacter(PlayerData player)
        {
            string sql = "INSERT OR IGNORE INTO " + Database.Player.table + "(" + Database.Player.name + ", " + Database.Player.ap + ", " + Database.Player.kutum + ") "
                + "VALUES ('" + player.name + "', " + player.ap + ", " + player.kutum + ");";

            database.Write(sql);
        }
        public static PlayerData loadCharacter(string name  = "")
        {
            string sql = "SELECT * FROM " + Database.Player.table + " WHERE ";

            if (name.Length > 0)
                sql += Database.Player.name + "='" + name + "';";
            else
                sql += Database.Player.id + "=1;";

            DataTable playerData = database.Read(sql);
            PlayerData player = new PlayerData();

            if (playerData != null)
            {
                if (playerData.Rows.Count > 0)
                {
                    player.name = playerData.Rows[0][Database.Player.name].ToString();
                    player.ap = playerData.Rows[0][Database.Player.ap].ToString();
                }
            }

            return player;
        }
        internal static string GetTotalTime(TreeNode node)
        {
            string sql = "SELECT duration FROM sessions";

            if (node == null)
                sql += ";";
            else if (node.Parent == null)
                sql += " JOIN rotations r ON sessions.rotation_id = r.rotation_id " +
                    "JOIN zones z ON z.zone_id = r.zone_id " +
                    "WHERE z.zone_id = " +GetLocationID(node)+";";
            else
                sql += " JOIN rotations r ON sessions.rotation_id = r.rotation_id " +
                    "WHERE r.rotation_id = " + GetLocationID(node) + ";";

            DataTable data = FetchData(sql);

            TimeSpan time = new TimeSpan();

            foreach(DataRow row in data.Rows)
            {
                time += TimeSpan.Parse(row[0].ToString());
            }

            return time.ToString();
        }

        //---Item Data---
        private static string GetItemID(ItemData item)
        {
            string sql = "SELECT item_id FROM items WHERE item_name = '"+item.name+"';";
            return FetchSingleData(sql);
        }
        internal static void AddItem(ItemData item)
        {
            string sql = "INSERT OR IGNORE INTO " + Database.Item.table + "(" + Database.Item.name + ", " + Database.Item.category + ", " + Database.Item.marketValue + ", " + Database.Item.vendorValue + ") "
                + "VALUES ('" + item.name + "', " + item.category + ", " + item.market + ", " + item.vendor + ");";

            database.Write(sql);
        }
        internal static void UpdatePrice(ItemData item)
        {
            string sql = "UPDATE items SET market_value = " + item.market + ", vendor_value = "+item.vendor+" WHERE " + Database.Item.name + " = '" + item.name + "';";

            database.Write(sql);
        }
        internal static ListViewItem[] GetItems()
        {
            string sql = "SELECT item_name FROM items ORDER BY item_name ASC;";
            DataTable data = FetchData(sql);
            List<ListViewItem> itemList = new List<ListViewItem>();

            foreach(DataRow row in data.Rows)
            {
                itemList.Add(new ListViewItem(row[0].ToString()));
            }

            return itemList.ToArray();
        }
        internal static void DeleteItem(ItemData item)
        {
            string sql = "PRAGMA foreign_keys=ON; DELETE FROM items WHERE item_name = '"+item.name+"';";
            database.Write(sql);
        }
        internal static void RemoveDrop(ItemData item, TreeNode node)
        {
            string sql = "";

            if(node.Parent == null)
                sql = "PRAGMA foreign_keys=ON; DELETE FROM zone_drops WHERE zone_id = " + GetLocationID(node) + " AND item_id = "+GetItemID(item)+";";
            else
            {
                sql = "INSERT INTO rotation_drops(rotation_id,item_id) VALUES (" + GetLocationID(node) + ", " + GetItemID(item) + ");";
            }

            database.Write(sql);
        }
        internal static int GetMaxPrice(string item, TreeNode node)
        {
            string sql = "SELECT market_value, vendor_value FROM items WHERE item_name = '"+item+"';";
            DataTable data = FetchData(sql);
            int[] prices = new int[2];
            int count = 0;

            try
            {
                prices[0] = Int32.Parse(data.Rows[0][0].ToString());
                prices[1] = Int32.Parse(data.Rows[0][1].ToString());
            }
            catch(Exception ex)
            {
                MessageBox.Show("No price data.");
                return -1;
            }

            try
            {
                if (node == null)
                    count = Int32.Parse(GetTotalAmountForItem(item));
                else
                    count = Int32.Parse(GetAmountForItem(item, node));

            }catch(Exception ex)
            {
                Debug.Write("No counts found.");
                count = 0;
            }

            return count * (prices[0] >= prices[1] ? prices[0] : prices[1]);
        }

        //---Session Data---
        internal static void SaveSession(Session session, List<Drop> drops)
        {
            string sql = "INSERT OR IGNORE INTO sessions(session_date, duration, rotation_id) " +
                "VALUES('"+session.date+"','"+session.duration+"',"+GetLocationID(session.rotation)+");";

            string id = database.Write(sql);
            foreach(Drop drop in drops)
            {
                RecordCount(id, drop);
            }
        }
        private static void RecordCount(string session, Drop drop)
        {
            string sql = "INSERT OR IGNORE INTO counts(session_id, item_id, count) " +
                "VALUES ("+session+","+GetItemID(new ItemData(drop.name))+","+drop.amount+");";

            database.Write(sql);
        }
        internal static List<Session> LoadSessions(TreeNode location)
        {
            string sql = "SELECT * FROM sessions";
            List<Session> sessions = new List<Session>();

            if (location != null)
            {
                if (location.Parent == null)
                    sql += " JOIN rotations r ON sessions.rotation_id = r.rotation_id " +
                        "JOIN zones z ON r.zone_id = z.zone_id " +
                        "WHERE z.zone_id = " + GetLocationID(location);
                else
                    sql += " WHERE rotation_id = " + GetLocationID(location);
            }

            sql += " ORDER BY session_date ASC;";

            DataTable data = FetchData(sql);

            foreach(DataRow row in data.Rows)
            {
                Session session = new Session();
                session.date = row[1].ToString();
                session.duration = row[2].ToString();
                sql ="SELECT rotation_name,zone_name FROM zones " +
                    "JOIN rotations r ON zones.zone_id = r.zone_id " +
                    "WHERE r.rotation_id = " + row[3].ToString() + ";";
                DataTable locationData = FetchData(sql);

                TreeNode zone = new TreeNode(locationData.Rows[0][1].ToString());
                TreeNode rotation = new TreeNode(locationData.Rows[0][0].ToString());
                zone.Nodes.Add(rotation);
                session.rotation = rotation;

                session.ap = row[4] == null ? "0" : row[4].ToString();
                session.scroll = row[5] == null ? "FALSE" : row[5].ToString();
                session.agris = row[6] == null ? "FALSE" : row[5].ToString();

                sessions.Add(session);
            }

            return sessions;
        }
        internal static void DeleteSession(string date)
        {
            string sql = "DELETE FROM sessions " +
                "WHERE session_date = '"+date+"';";

            database.Write(sql);
        }
    }
}
