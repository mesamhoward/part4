<%@ Page Language="C#" Inherits="store_part3.checkout" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>checkout</title> 
    <meta charset="utf-8">
    <link id="callCss" rel="stylesheet" href="css/bootstrap.min.css" media="screen"/>

</head>
<body>
    <nav class="topnav">
    <h4> <a class="btn" href="Default.aspx">Home</a>
      <a class="btn" href="contact.aspx"> Contact</a>
      <a class="btn" href="checkout.aspx"> Checkout</a>
      <a class="btn" href="orders.aspx"> My orders</a>
    </h4>

  </nav>
  <form id="form3" runat="server">
        <asp:Button id="button3" runat="server" Text="Clear Cart" OnClick="button3Clicked" />
             <asp:Button id="button4" runat="server" Text="Order" OnClick="button4Clicked" />
    </form>
   
   <h3 runat="server" id="price_spot"></h3>

  <div class="banner-image">
    <div class="banner-text">
      <h3>Computer Store</h3>
      <p> In my Cart </p>
    </div>
  </div>
	<form id="form1" runat="server">
	</form>
    <p  runat="server" id="products"></p>
    
</body>
</html>
