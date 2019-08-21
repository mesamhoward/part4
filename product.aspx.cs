using System;
using System.Web;
using System.Web.UI;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;


namespace store_part3
{
    public class prod
    {
        public string name { get; set; }
        public string des { get; set; }
        public string src { get; set; }
        public float base_price { get; set; }
    }
    public class cart
    {

        public string ram { get; set; }
        public string drive { get; set; }
        public string cpu { get; set; }
        public string monitor { get; set; }
        public string os { get; set; }
        public string sound { get; set; }
        public float price { get; set; }
        public string type { get; set; }
        public prod poduct { get; set; }


    }
    public class carts
    {
        public cart[] all_items { get; set; }

        public static cart[] InitializeArray(int length)
        {
            cart[] array = new cart[length];
            for (int i = 0; i < length; ++i)
            {
                array[i] = new cart();
            }

            return array;
        }
    }


    



    public partial class product : System.Web.UI.Page
    {
        public prod product1 { get; set; }
        public float base_price { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            
            base.OnLoad(e);
            //Response.Cookies["checkout"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie myCookie = Request.Cookies["prod"];
            prod myObjectJson = new JavaScriptSerializer().Deserialize<prod>(myCookie.Value);
            product1 = myObjectJson;

            image.InnerHtml = "<img src =" +'"' + product1.src + '"' + " alt =" + '"' + '"' + "/>";
            name.InnerHtml = product1.name;
            des.InnerHtml = product1.des;
            base_price = product1.base_price;


        }

            //configure
            public void button3Clicked(object sender, EventArgs args)
        {
            
            cart cart_1 = new cart();
            
            float price = 0;
            Regex rx = new Regex(@"(.+)?\$(.+)",
          RegexOptions.Compiled | RegexOptions.IgnoreCase);

            string ram = Request.Form["ram"];


            MatchCollection matches = rx.Matches(ram);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.ram = name;
                price += float.Parse(p,System.Globalization.CultureInfo.InvariantCulture);
                 


            }


            string drive = Request.Form["Hard Drive"];


            matches = rx.Matches(drive);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.drive = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string CPU = Request.Form["CPU"];


            


            matches = rx.Matches(CPU);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.cpu = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }
            string monitor = Request.Form["monitor"];

            matches = rx.Matches(monitor);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.monitor = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }
            string os = Request.Form["os"];

            matches = rx.Matches(os);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.os = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }

            string sound = Request.Form["sound"];

            matches = rx.Matches(sound);

            foreach (Match match in matches)
            {

                GroupCollection groups = match.Groups;

                string p = groups[2].Value;
                string name = groups[1].Value;
                cart_1.sound = name;
                price += float.Parse(p, System.Globalization.CultureInfo.InvariantCulture);



            }
            price = price + base_price;
            cart_1.price = price;
            cart_1.poduct = product1;
            string bas = "Added to your cart with a price of $";
            price_spot.InnerText = bas + price.ToString();
            

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
                cart[] carts_list = carts.InitializeArray(list.Length+1);

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

        
    }

    


}
