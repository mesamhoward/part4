using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace store_part3
{

    public partial class Default : System.Web.UI.Page
    {
        public void makcomel(cart cart1, Button button5, Button button1, System.Web.UI.HtmlControls.HtmlContainerControl product, System.Web.UI.HtmlControls.HtmlContainerControl des, System.Web.UI.HtmlControls.HtmlContainerControl im, System.Web.UI.HtmlControls.HtmlContainerControl price)
        {
            string cmd = cart1.poduct.base_price.ToString() + '|' + cart1.poduct.name + '|' + cart1.poduct.des + '|' + cart1.poduct.src;
            button5.CommandArgument = cmd;
            string cmd2 = cart1.price.ToString() + '|' + cart1.poduct.name + '|' + cart1.poduct.des + '|' + cart1.poduct.src;
            button1.CommandArgument = cmd2;

            product.InnerText = cart1.poduct.name;
            des.InnerText = cart1.poduct.des;

            im.InnerHtml = "<img src = '" + cart1.poduct.src + "' alt = '' class='center' />";
            price.InnerText = '$' + cart1.price.ToString();


        }

        public void makereg(cart cart2, Button button2, System.Web.UI.HtmlControls.HtmlContainerControl product, System.Web.UI.HtmlControls.HtmlContainerControl des, System.Web.UI.HtmlControls.HtmlContainerControl im, System.Web.UI.HtmlControls.HtmlContainerControl price)
        {
            string cmd = cart2.poduct.base_price.ToString() + '|' + cart2.poduct.name + '|' + cart2.poduct.des + '|' + cart2.poduct.src;
            button2.CommandArgument = cmd;
            product.InnerText = cart2.poduct.name;

            des.InnerText = cart2.poduct.des;

            im.InnerHtml = "<img src = '" + cart2.poduct.src + "' alt = '' align=" + '"' + "middle" + '"' + "/>";
            price.InnerText = '$' + cart2.price.ToString();


        }

        public cart compcart(prod product)
        {
            cart cart1 = new cart();

            prod p1 = new prod();
            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE name1 = @label", connection))
                {

                    command_comp.Parameters.AddWithValue("@label", product.name);
                    connection.Open();
                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                    {
                        while (reader_comp.Read())
                        {
                            
                            cart1.price = float.Parse(reader_comp["standard_price"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            break;
                        }
                    }
                }
            }

            cart1.poduct = product;
            
            cart1.ram = "G.SKILL Ripjaws V Series 8GB";
            cart1.drive = "WD Blue 1TB";
            cart1.cpu = "Intel Core i5-8400";
            cart1.monitor = "ASUS VP249HE Eye Care Monitor 23.8";
            cart1.os = "Windows 10 Home";
            cart1.sound = "Creative Sound Blaster Audigy RX 7.1";
            return cart1;

        }

        public prod get_prod(string label)
        {
            prod p1 = new prod();
            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                using (SqlCommand command_comp = new SqlCommand("SELECT * FROM product WHERE name1 = @label", connection))
                {
                    
                    command_comp.Parameters.AddWithValue("@label", label);
                    connection.Open();
                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                    {
                        while (reader_comp.Read())
                        {
                     
                            p1.name = reader_comp["name1"].ToString();
                            p1.src = reader_comp["src"].ToString();
                            p1.des = reader_comp["des"].ToString();
                            p1.base_price = float.Parse(reader_comp["price"].ToString(), System.Globalization.CultureInfo.InvariantCulture);

                            break;
                        }
                    }
                }
            }
            return p1;

        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            List<string> labels = new List<string>();
            
            string _connectionString = "Server = tcp:comp466.database.windows.net,1433; Initial Catalog = comp466; Persist Security Info = False; User ID = samh@COMP466; Password = test123$$$; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {


                using (SqlCommand command_comp = new SqlCommand("SELECT name1 FROM product", connection))
                {

                    
                    connection.Open();
                    using (SqlDataReader reader_comp = command_comp.ExecuteReader())
                    {
                        int i = 0;
                        while (reader_comp.Read() && i <= 4)
                        {
                            
                            labels.Add(reader_comp["name1"].ToString());
                            

                            i++;
                        }
                    }
                }
            }

            prod p = get_prod(labels[1]) ;
            cart cart1 = compcart(p);
            makcomel(cart1, button5, button1, product1, des1, im1, price1);

            prod p2 = get_prod(labels[0]);
            cart cart2 = new cart();
            cart2.poduct = p2;
            cart2.price = 10F;
            makereg(cart2, button2, product2, des2, im2, price2);



            prod p3 = get_prod(labels[2]);
            cart cart3 = compcart(p3);
            makcomel(cart3, button6, button4, product3, des3, im3, price3);


            prod p4 = get_prod(labels[3]);
            cart cart4 = new cart();
            cart4.poduct = p4;
            cart4.price = 59.99F;
            makereg(cart4, button7, product4, des4, im4, price4);



        }


        public void button1Clicked(object sender, CommandEventArgs e)
        {
            prod product1 = new prod();
            String[] spearator = { "|" };
            int count = 4;
            String[] strlist = e.CommandArgument.ToString().Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);


            float price = float.Parse(strlist[0], System.Globalization.CultureInfo.InvariantCulture);
            string des = strlist[2];
            string name = strlist[1];
            string src = strlist[3];

            product1.base_price = price;
            product1.des = des;
            product1.name = name;
            product1.src = src;


            cart cart_1 = new cart();
            cart_1.poduct = product1;
            cart_1.price = product1.base_price;


            //create cookie with array and price
            HttpCookie myCookie = Request.Cookies["checkout"];
            if (myCookie == null)
            {
                cart[] carts_list = carts.InitializeArray(1);
                carts_list[0] = cart_1;
                carts cart_class = new carts();
                cart_class.all_items = carts_list;


                string myObjectJson = new JavaScriptSerializer().Serialize(cart_class);
                var cookie = new HttpCookie("checkout", myObjectJson)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {


                HttpCookie cook = HttpContext.Current.Request.Cookies["checkout"];


                carts myObjectJson = new JavaScriptSerializer().Deserialize<carts>(cook.Value);

                cart[] list = myObjectJson.all_items;
                cart[] carts_list = carts.InitializeArray(list.Length + 1);

                int n = 0;
                while (n < list.Length)
                {
                    carts_list[n] = list[n];
                    n++;
                }
                carts_list[list.Length] = cart_1;
                carts cart_class = new carts();
                cart_class.all_items = carts_list;
                string myObjectJson2 = new JavaScriptSerializer().Serialize(cart_class);
                cook = new HttpCookie("checkout", myObjectJson2)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cook);


            }
        }
        public void button2Clicked(object sender, CommandEventArgs e)
        {
            
            prod product1 = new prod();
            String[] spearator = { "|" };
            int count = 4;
            String[] strlist = e.CommandArgument.ToString().Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);


            float price = float.Parse(strlist[0], System.Globalization.CultureInfo.InvariantCulture);
            string des = strlist[2];
            string name = strlist[1];
            string src = strlist[3];

            product1.base_price = price;
            product1.des = des;
            product1.name = name;
            product1.src = src;
            

            cart cart_1 = new cart();
            cart_1.poduct = product1;
            cart_1.price = product1.base_price;


            //create cookie with array and price
            HttpCookie myCookie = Request.Cookies["checkout"];
            if (myCookie == null)
            {
                cart[] carts_list = carts.InitializeArray(1);
                carts_list[0] = cart_1;
                carts cart_class = new carts();
                cart_class.all_items = carts_list;


                string myObjectJson = new JavaScriptSerializer().Serialize(cart_class);
                var cookie = new HttpCookie("checkout", myObjectJson)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {


                HttpCookie cook = HttpContext.Current.Request.Cookies["checkout"];


                carts myObjectJson = new JavaScriptSerializer().Deserialize<carts>(cook.Value);

                cart[] list = myObjectJson.all_items;
                cart[] carts_list = carts.InitializeArray(list.Length + 1);

                int n = 0;
                while (n < list.Length)
                {
                    carts_list[n] = list[n];
                    n++;
                }
                carts_list[list.Length] = cart_1;
                carts cart_class = new carts();
                cart_class.all_items = carts_list;
                string myObjectJson2 = new JavaScriptSerializer().Serialize(cart_class);
                cook = new HttpCookie("checkout", myObjectJson2)
                {
                    Expires = DateTime.Now.AddYears(1)
                };
                HttpContext.Current.Response.Cookies.Add(cook);


            }
        }

        public void button5Clicked(object sender, CommandEventArgs e)
        {


            prod product1 = new prod();
            String[] spearator = { "|" };
            int count = 4;
            String[] strlist = e.CommandArgument.ToString().Split(spearator, count,
               StringSplitOptions.RemoveEmptyEntries);


            float price = float.Parse(strlist[0], System.Globalization.CultureInfo.InvariantCulture);
            string des = strlist[2];
            string name = strlist[1];
            string src = strlist[3];

            product1.base_price = price;
            product1.des = des;
            product1.name = name;
            product1.src = src;


            cart cart_1 = new cart();
            cart_1.poduct = product1;
            cart_1.price = product1.base_price;

            
            string myObjectJson3 = new JavaScriptSerializer().Serialize(product1);
            HttpCookie myCookie = new HttpCookie("prod", myObjectJson3)
            {
                Expires = DateTime.Now.AddYears(1)
            };
            HttpContext.Current.Response.Cookies.Add(myCookie);
            Response.Redirect("product.aspx");
        }



    }
}
