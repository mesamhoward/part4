using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace store_part3
{

    public partial class checkout : System.Web.UI.Page
    {
        public float total { get; set; }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string write = "";
            HttpCookie myCookie = Request.Cookies["checkout"];
            if (myCookie != null)
            {
                carts myObjectJson = new JavaScriptSerializer().Deserialize<carts>(myCookie.Value);

                cart[] list = myObjectJson.all_items;
                int n = 0;
                while (n < list.Length)
                {
                    cart add = list[n];
                    total = total + add.price;
                    if (add.ram == null)
                    {
                        write += "<li class='span3'><div class='thumbnail'><a><img src ='" + add.poduct.src + "' alt=''/></a><div class='caption'><h5>"+add.poduct.name +"</h5><p>"+ add.poduct.des +  "</p><p>$" + add.price + "</p><h4 style = 'text-align:center' >  </ h4 ></ div ></ div > </li>";
                    }
                    else
                    {
                        write += "<li class='span3'><div class='thumbnail'><a><img src ='" + add.poduct.src + "' alt=''/></a><div class='caption'><h5>" + add.poduct.name + "</h5><p>" + add.poduct.des + "</p><p>Ram: " + add.ram + "</p><p>Hard Drive: " + add.drive + "</p><p>CPU: " + add.cpu + "</p><p>Display: " + add.monitor + "</p><p>OS: " + add.os + "</p><p>Sound Card: " + add.sound + "</p><p>$" + add.price + "</p><h4 style = 'text-align:center' >  </ h4 ></ div ></ div > </li>";
                    }
                    
                    n++;
                }



            }



            products.InnerHtml = write;
            string bas = "Total price $";
            price_spot.InnerText = bas + total.ToString();
        }
        public void button3Clicked(object sender, EventArgs args)
        {
            Response.Cookies["checkout"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("checkout.aspx");
        }
        public void button4Clicked(object sender, EventArgs args)
        {
            HttpCookie myCookie = Request.Cookies["checkout"];
            HttpCookie myCookie2 = Request.Cookies["user"];
            if (myCookie != null)
            {
                //write to db
                if(myCookie2 != null)
                {
                    carts myObjectJson = new JavaScriptSerializer().Deserialize<carts>(myCookie.Value);

                    cart[] list = myObjectJson.all_items;
                    int n = 0;
                    while (n < list.Length)
                    {
                        cart add = list[n];

                        if (add.ram == null)
                        {
                            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                            using (SqlConnection connection = new SqlConnection(_connectionString))
                            {

                                int id = 0;
                                string p = "";
                                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE name1 = @label", connection))
                                {
                                    string label = add.poduct.name;
                                    command_comp.Parameters.AddWithValue("@label", label);
                                    connection.Open();
                                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                                    {
                                        while (reader_comp.Read())
                                        {
                                            id = System.Convert.ToInt32(reader_comp["prod_id"]);
                                            if (reader_comp["type"].ToString() == "comp")
                                            {
                                                p = add.price.ToString();
                                            }
                                            else
                                            {
                                                p = reader_comp["price"].ToString();
                                            }

                                            
                                            break;
                                        }
                                    }
                                    
                                    using (SqlConnection connection1 = new SqlConnection(_connectionString))
                                    {
                                        String query = "INSERT INTO Orders (username,prod_id, price, type) VALUES (@username, @id, @price, 'reg')";
                                        using (SqlCommand command = new SqlCommand(query, connection1))
                                        {
                                            command.Parameters.AddWithValue("@id", id);
                                            command.Parameters.AddWithValue("@price", p);
                                            command.Parameters.AddWithValue("@username", myCookie2.Value);


                                            connection1.Open();
                                            int result = command.ExecuteNonQuery();



                                        }
                                    }
                                }


                            }
                        }
                        else
                        {
                            int id = 0;
                            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                            using (SqlConnection connection = new SqlConnection(_connectionString))
                            {

                                
                                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE name1 = @label", connection))
                                {
                                    string label = add.poduct.name;
                                    command_comp.Parameters.AddWithValue("@label", label);
                                    connection.Open();
                                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                                    {
                                        while (reader_comp.Read())
                                        {
                                            id = System.Convert.ToInt32(reader_comp["prod_id"]);
                                            break;
                                        }
                                    }
                                }
                            }

                                    using (SqlConnection connection1 = new SqlConnection(_connectionString))
                                    {
                                        String query = "INSERT INTO Orders (username,prod_id,ram, drive, cpu, monitor, os, sound, price, type) VALUES (@username, @id, @ram, @drive, @cpu, @monitor, @os, @sound, @price, 'comp')";
                                        using (SqlCommand command = new SqlCommand(query, connection1))
                                        {
                                            command.Parameters.AddWithValue("@id", id);
                                            command.Parameters.AddWithValue("@ram", add.ram);
                                            command.Parameters.AddWithValue("@username", myCookie2.Value);
                                            command.Parameters.AddWithValue("@drive", add.drive);
                                            command.Parameters.AddWithValue("@cpu", add.cpu);
                                            command.Parameters.AddWithValue("@monitor", add.monitor);
                                            command.Parameters.AddWithValue("@os", add.os);
                                            command.Parameters.AddWithValue("@sound", add.sound);
                                            command.Parameters.AddWithValue("@price", add.price);
                                            

                                            connection1.Open();
                                            int result = command.ExecuteNonQuery();



                                        }
                                    }
                                


                            
                        }

                        n++;
                    }
                }
                else
                {
                    string message = "Please Login on My orders page";
                    price_spot.InnerText = message;
                    
                }
                



            }

        }
    }
}