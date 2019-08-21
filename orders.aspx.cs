using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Web;
using System.Web.UI;

namespace store_part3
{

    public partial class orders : System.Web.UI.Page
    {

        protected override void OnLoad(EventArgs e)
        {

            base.OnLoad(e);
            signForm1.Visible = false;
            forgot.Visible = false;
            button7.Visible = false;
            myForm.Visible = false;
            signForm1.Visible = false;
            button13.Visible = false;
            button7.Visible = false;
            myForm.Visible = false;
            signForm1.Visible = false;
            forgot.Visible = false;
            button13.Visible = false;
            button14.Visible = false;
            button15.Visible = false;
            HttpCookie myCookie = Request.Cookies["user"];
            if (myCookie == null)
            {
                display.InnerText = "Please login to view your orders";
                myForm.Visible = true;
                button13.Visible = true;
                button7.Visible = true;
            }
            else
            {
                string username = myCookie.Value;
                string write = "";
                button14.Visible = true;
                button15.Visible = true;
                using (SqlConnection connection = new SqlConnection(@"Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
                {

                    using (SqlCommand command = new SqlCommand("SELECT * FROM Orders WHERE username = @username", connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


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
                                                prod prod1 = new prod();
                                                cart add = new cart();
                                                
                                                prod1.base_price = float.Parse(reader_comp["price"].ToString(), CultureInfo.InvariantCulture.NumberFormat);
                                                prod1.name = reader_comp["name1"].ToString();
                                                prod1.src = reader_comp["src"].ToString();
                                                prod1.des = reader_comp["des"].ToString();
                                                add.poduct = prod1;
                                                add.ram = reader["ram"].ToString();
                                                
                                                add.drive = reader["drive"].ToString();
                                                add.cpu = reader["cpu"].ToString();
                                                add.monitor = reader["monitor"].ToString();
                                                add.os = reader["os"].ToString();
                                                add.sound = reader["sound"].ToString();
                                                
                                                add.price = float.Parse(reader["price"].ToString(), CultureInfo.InvariantCulture.NumberFormat);

                                                if (reader["type"].ToString() == "reg")
                                                {
                                                    write += "<li><span3><div class='thumbnail'><a><img src ='" + add.poduct.src + "' alt=''/></a><div class='caption'><h5>" + add.poduct.name + "</h5><p>" + add.poduct.des + "</p><p>$" + add.price + "</p><h4 style = 'text-align:center' >  </ h4 ></ div ></ div ></span3> </li>";
                                                }
                                                else
                                                {
                                                    write += "<li><span3><div class='thumbnail'><a><img src ='" + add.poduct.src + "' alt=''/></a><div class='caption'><h5>" + add.poduct.name + "</h5><p>" + add.poduct.des + "</p><p>Ram: " + add.ram + "</p><p>Hard Drive: " + add.drive + "</p><p>CPU: " + add.cpu + "</p><p>Display: " + add.monitor + "</p><p>OS: " + add.os + "</p><p>Sound Card: " + add.sound + "</p><p>$" + add.price + "</p><h4 style = 'text-align:center' >  </ h4 ></ div ></ div ></span3> </li>";
                                                }

                                            }

                                        }

                                    }
                                }



                            }

                        }

                    }
                }

                products.InnerHtml = write;
            }
            

        }
        public void login(object sender, EventArgs e)
        {
            string user = user1.Value;
            string pass = psw.Value;
            Boolean flag = false;

            using (SqlConnection connection = new SqlConnection(@"Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {

                using (SqlCommand command = new SqlCommand("SELECT * FROM Login", connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        


                        while (reader.Read())
                        {
                            string curuse = reader["username"].ToString();
                            if (curuse == user)
                            {
                                if(reader["password"].ToString() == pass)
                                {
                                    flag = true;
                                    break;
                                }
                            }



                        }
                        
                    }



                }
            }

            if(flag == true)
            {
                var cookie = new HttpCookie("user", user)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);

                Page.Response.Redirect("orders.aspx", true);
            }
            else
            {
                error.InnerText = "Incorrect Login";
            }

        
    }
        public void signForm(object sender, EventArgs e)
        {
            button7.Visible = false;
            myForm.Visible = false;
            signForm1.Visible = true;
            button13.Visible = false;
        }
        public void logout(object sender, EventArgs e)
        {

            Response.Cookies["user"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("orders.aspx");
        }
        public void edit(object sender, EventArgs e)
        {
            Page.Response.Redirect("edit.aspx", true);

        }
        public void forg(object sender, EventArgs e)
        {
            

        }
        public void logForm(object sender, EventArgs e)
        {
            button13.Visible = true;
            button7.Visible = true;
            myForm.Visible = true;
            signForm1.Visible = false;
            
        }
        public void forgotForm(object sender, EventArgs e)
        {
            button7.Visible = false;
            myForm.Visible = false;
            signForm1.Visible = false;
            forgot.Visible = true;
            button13.Visible = false;

        }
        public void sign(object sender, EventArgs e)
        {
            string user = user2.Value;
            string pass1 = psw2.Value;
            string pass2 = psw3.Value;

            if (pass1 != pass2)
            {
                error.InnerText = "Passwords do not match.";
            }
            else
            {
                string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
                using (SqlConnection connection1 = new SqlConnection(_connectionString))
                {
                    String query = "INSERT INTO Login (username,password) VALUES (@username, @password)";
                    using (SqlCommand command = new SqlCommand(query, connection1))
                    {
                        
                        command.Parameters.AddWithValue("@username", user);
                        command.Parameters.AddWithValue("@password", pass1);
                        


                        connection1.Open();
                        int result = command.ExecuteNonQuery();


                    }
                }
                var cookie = new HttpCookie("user", user)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);

                Page.Response.Redirect("orders.aspx", true);
            }
        }
    }
}
