<%@ Page Language="C#" Inherits="store_part3.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>Home Page</title>
    <link id="callCss" rel="stylesheet" href="css/bootstrap.min.css" media="screen"/>

</head>
<body>
    
    
  <nav class="topnav">
    <h4> <a class="btn" href="">Home</a>
      <a class="btn" href="contact.aspx"> Contact</a>
      <a class="btn" href="checkout.aspx"> Checkout</a>
      <a class="btn" href="orders.aspx"> My orders</a>
    </h4>

  </nav>

  <div class="banner-image">
    <div class="banner-text">
      <h3>Computer Store</h3>
      <p> Check out some products below </p>
    </div>
  </div>
  <p  runat="server" id="products"></p>

  <li ><span3 >
    <div class="thumbnail">
    <a style="text-align:center"runat="server" id="im1"></a>
    <div class="caption">
      <h5 style="text-align:center" runat="server" id="product1"></h5>
      <p style="text-align:center" runat="server" id="des1">
      
      
      </p>
      <h5 style="text-align:center" runat="server" id="price1"></h5>
     <h4 style="text-align:center"> <form id="form1" runat="server">
        <asp:Button id="button1" runat="server" Text="Add to Cart" CommandName="pass" OnCommand="button1Clicked" CommandArgument=""/>
        </form> 
        <form id="form3" runat="server">
            <asp:Button id="button5" runat="server" Text="Configure" CommandName="pass" OnCommand="button5Clicked" CommandArgument=""/>
            
        </form> </h4>
    </div>
    </div>
            </span3>
  </li>
        
        
  

  <li ><span3 >
    <div class="thumbnail">
                
    <a style="text-align:center" runat="server" id="im2" ></a>
    <div class="caption">
      <h5 style="text-align:center" runat="server" id="product2"></h5>
      <p style="text-align:center" runat="server" id="des2"></p>
      <h5 style="text-align:center" runat="server" id="price2"></h5>
     <h4 style="text-align:center"> <form id="form2" runat="server">
        <asp:Button id="button2" runat="server" Text="Add to Cart" CommandName="pass" OnCommand="button2Clicked" CommandArgument=""/>
    </form> </h4>
    </div>
    </div>
                </span3 >
  </li>
        
  <li ><span3 >
    <div class="thumbnail">
    <a style="text-align:center" runat="server" id="im3"></a>
    <div class="caption">
      <h5 style="text-align:center" runat="server" id="product3"></h5>
      <p style="text-align:center" runat="server" id="des3">
      
      
      </p>
      <h5 style="text-align:center" runat="server" id="price3"></h5>
     <h4 style="text-align:center"> <form id="form4" runat="server">
        <asp:Button id="button4" runat="server" Text="Add to Cart" CommandName="pass" OnCommand="button1Clicked" CommandArgument=""/>
        </form> 
        <form id="form5" runat="server">
            <asp:Button id="button6" runat="server" Text="Configure" CommandName="pass" OnCommand="button5Clicked" CommandArgument=""/>
            
        </form> </h4>
    </div>
    </div>
                </span3 >
  </li>
        
  <li ><span3 >
    <div class="thumbnail">
                
    <a style="text-align:center" runat="server" id="im4"></a>
    <div class="caption">
      <h5 style="text-align:center" runat="server" id="product4"></h5>
      <p style="text-align:center" runat="server" id="des4"></p>
      <h5 style="text-align:center" runat="server" id="price4"></h5>
     <h4 style="text-align:center"> <form id="form6" runat="server">
        <asp:Button id="button7" runat="server" Text="Add to Cart" CommandName="pass" OnCommand="button2Clicked" CommandArgument=""/>
    </form> </h4>
    </div>
    </div>
                </span3 >
  </li>
</body>
</html>

