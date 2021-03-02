using System;
using System.Collections.Generic;
using System.Text;

namespace BDO_Grind_Tracker.Test
{
    static class TestData
    {
        private static Database db = new Database();
        public static void FillData()
        {
            Player();
            Zone();
            Rotation();
            Items();
            Drops();
            Session();
            Amounts();
        }

        public static void Player()
        {
            db.Write("INSERT INTO players(player_name, ap, kutum) VALUES('Lil_Scrub', 268, TRUE);");
        }
        public static void Items()
        {
            db.Write("INSERT INTO items(item_name,category,market_value,vendor_value) VALUES ('Beer', 6,1000,10);");
            db.Write("INSERT INTO items(item_name,category,market_value,vendor_value) VALUES ('Sword', 2,100000,1000);");
            db.Write("INSERT INTO items(item_name,category,market_value,vendor_value) VALUES ('Leaf', 1, 0, 2000);");
            db.Write("INSERT INTO items(item_name,category,market_value,vendor_value) VALUES ('Token', 1, 0, 8000);");
        }
        public static void Zone()
        {
            db.Write("INSERT INTO zones(zone_name) VALUES('Tshira Ruins');");
            db.Write("INSERT INTO zones(zone_name) VALUES('Manshuam Forest');");
            db.Write("INSERT INTO zones(zone_name) VALUES('Some place');");
        }
        public static void Rotation()
        {
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Main', 1);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Back', 1);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Pot Piece', 1);");

            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Main', 2);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('21 Shamans', 2);");

            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Main', 3);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Back', 3);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Money', 3);");
            db.Write("INSERT INTO rotations(rotation_name, zone_id) VALUES ('Secondary', 3);");

        }
        public static void Drops()
        {
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (1,1);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (1,2);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (1,3);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (1,4);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (2,1);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (2,4);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (3,3);");
            db.Write("INSERT INTO zone_drops(zone_id,item_id) VALUES (3,4);");

            db.Write("INSERT INTO rotation_drops(rotation_id, item_id) VALUES (3,3);");
            db.Write("INSERT INTO rotation_drops(rotation_id, item_id) VALUES (9,1);");
            db.Write("INSERT INTO rotation_drops(rotation_id, item_id) VALUES (9,3);");
        }
        public static void Session()
        {
            db.Write("INSERT INTO sessions(session_date,duration,rotation_id,ap,scroll,agris) VALUES ('2021-2-10 4:25','1:23:15',2,268,FALSE,TRUE);");
            db.Write("INSERT INTO sessions(session_date,duration,rotation_id,ap,scroll,agris) VALUES ('2021-2-10 10:30','2:15:15',2,268,FALSE,TRUE);");
            db.Write("INSERT INTO sessions(session_date,duration,rotation_id,ap,scroll,agris) VALUES ('2021-2-10 20:25','1:10:15',2,268,TRUE,TRUE);");
        }
        public static void Amounts()
        {
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (1,1,100);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (1,2,1);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (1,3,200);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (2,1,200);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (2,2,4);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (2,3,156);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (3,1,75);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (3,2,0);");
            db.Write("INSERT INTO counts(session_id, item_id, count) VALUES (3,3,124);");
        }
    }
}
