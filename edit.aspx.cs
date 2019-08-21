using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace store_part3
{

    public partial class edit : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e)
        {
            form2.Visible = false;
            HttpCookie myCookie = Request.Cookies["user"];
            string username = myCookie.Value;
            
            using (SqlConnection connection = new SqlConnection(@"Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {

                using (SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE username = @username", connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        list1.Items.Clear();
                        while (reader.Read())
                        {
                            string curuse = reader["username"].ToString();
                            if (curuse == username)
                            {
                                int label = System.Convert.ToInt32(reader["prod_id"]);
                                SqlConnection connection1 = new SqlConnection(@"Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;");
                                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE prod_id = @label", connection1))
                                {
                                    command_comp.Parameters.AddWithValue("@label", label);
                                    connection1.Open();
                                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                                    {

                                        while (reader_comp.Read())
                                        {
                                            

                                            string name = reader_comp["name1"] + "|" + reader["oder_id"] + "|" + reader_comp["type"];
                                            list1.Items.Add(name);

                                            

                                        }
                                        

                                    }

                                }
                            }



                        }
                        

                    }

                }
            }

            
        }

        public void del(object sender, EventArgs e)
        {
            string sVal = list1.Items[list1.SelectedIndex].Value;

            char[] spearator = { '|' };
            Int32 count = 3;

            String[] strlist = sVal.Split(spearator,
                   count, StringSplitOptions.None);

            string name1 = strlist[0];

            int id = Int32.Parse(strlist[1]);
            string ConnectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (var sc = new SqlConnection(ConnectionString))
            using (var cmd = sc.CreateCommand())
            {
                sc.Open();
                cmd.CommandText = "DELETE FROM Orders WHERE oder_id = @word";
                cmd.Parameters.AddWithValue("@word", id);
                cmd.ExecuteNonQuery();
            }

        }
        
        public void config(object sender, EventArgs e)
        {
            string sVal = list1.Items[list1.SelectedIndex].Value;
            
            char[] spearator = { '|'};
            Int32 count = 3;

            String[] strlist = sVal.Split(spearator,
                   count, StringSplitOptions.None);

            string name = strlist[0];

            string id = strlist[1];

            string ty = strlist[2];
            if (ty == "reg")
            {
                sel.InnerText = "Cannot Configure a Regular item";
            }
            else
            {
                form2.Visible = true;
            }

        }
        public void cancel(object sender, EventArgs e)
        {

            Page.Response.Redirect("orders.aspx", true);
        }
        public void button4Clicked(object sender, EventArgs e)
        {

            string sVal = list1.Items[list1.SelectedIndex].Value;

            char[] spearator = { '|' };
            Int32 count = 3;

            String[] strlist = sVal.Split(spearator,
                   count, StringSplitOptions.None);

            string name1 = strlist[0];

            int id = Int32.Parse(strlist[1]);
            string ConnectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (var sc = new SqlConnection(ConnectionString))
            using (var cmd = sc.CreateCommand())
            {
                sc.Open();
                cmd.CommandText = "DELETE FROM Orders WHERE oder_id = @word";
                cmd.Parameters.AddWithValue("@word", id);
                cmd.ExecuteNonQuery();
            }

            cart cart_1 = new cart();

            float price = 0;
            Regex rx = new Regex(@"(.+)?\$(.+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string ram1 = ram.Items[ram.SelectedIndex].Value;


            MatchCollection matches = rx.Matches(ram1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.ram = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }


            
            string drive1 = drive.Items[drive.SelectedIndex].Value;


            matches = rx.Matches(drive1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.drive = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string cpu1 = cpu.Items[cpu.SelectedIndex].Value;



            matches = rx.Matches(cpu1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.cpu = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string monitor1 = monitor.Items[monitor.SelectedIndex].Value;
            

            matches = rx.Matches(monitor1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.monitor = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string os1 = os.Items[os.SelectedIndex].Value;
            

            matches = rx.Matches(os1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.os = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string sound1 = sound.Items[sound.SelectedIndex].Value;
            

            matches = rx.Matches(sound1);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.sound = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }
            prod product1 = new prod();
            float base_price = 0.00F;
            int prod_id = 0;
            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE name1 = @label", connection))
                {

                    command_comp.Parameters.AddWithValue("@label", name1);
                    connection.Open();
                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                    {
                        while (reader_comp.Read())
                        {

                            base_price = float.Parse(reader_comp["price"].ToString(), System.Globalization.CultureInfo.InvariantCulture);
                            product1.base_price = base_price;
                            product1.des = reader_comp["des"].ToString();
                            product1.src = reader_comp["src"].ToString();
                            product1.name = name1;
                            prod_id = System.Convert.ToInt32(reader_comp["prod_id"]);

                            break;
                        }
                    }
                }


                price = price + base_price;
                cart_1.price = price;
                cart_1.poduct = product1;
                string bas = "Added to your order with a price of $";
                price_spot.InnerText = bas + price.ToString();


                HttpCookie myCookie2 = Request.Cookies["user"];
                using (SqlConnection connection1 = new SqlConnection(_connectionString))
                {
                    String query = "INSERT INTO Orders (username,prod_id,ram, drive, cpu, monitor, os, sound, price, type) VALUES (@username, @id, @ram, @drive, @cpu, @monitor, @os, @sound, @price, 'comp')";
                    using (SqlCommand command = new SqlCommand(query, connection1))
                    {
                        command.Parameters.AddWithValue("@id", prod_id);
                        command.Parameters.AddWithValue("@ram", cart_1.ram);
                        command.Parameters.AddWithValue("@username", myCookie2.Value);
                        command.Parameters.AddWithValue("@drive", cart_1.drive);
                        command.Parameters.AddWithValue("@cpu", cart_1.cpu);
                        command.Parameters.AddWithValue("@monitor", cart_1.monitor);
                        command.Parameters.AddWithValue("@os", cart_1.os);
                        command.Parameters.AddWithValue("@sound", cart_1.sound);
                        command.Parameters.AddWithValue("@price", cart_1.price);


                        connection1.Open();
                        int result = command.ExecuteNonQuery();


                    }
                }



            }



        }
    }
    
}
