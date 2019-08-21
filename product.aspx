<%@ Page Language="C#" Inherits="store_part3.product" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>Home Page</title>
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

  <div class="banner-image">
    <div class="banner-text">
      <h3>Computer Store</h3>
      <p> Configure your product below </p>
    </div>
  </div>
        
  <li class="span3">
    <div class="thumbnail">
    <a runat="server" id="image" ></a>
    
    <div class="caption">
      <h5 runat="server" id="name"></h5>
      <p runat="server" id="des"></p>

   
    </div>
    </div>
  </li>
  
    
        
  <form id="form1" runat="server" >
        Ram: <br />
        <select name="ram" form="form1">
          <option value="G.SKILL Ripjaws V Series 8GB $99.99">G.SKILL Ripjaws V Series 8GB $99.99</option>
          <option value="G.SKILL TridentZ RGB Series 16GB $141.99">G.SKILL TridentZ RGB Series 16GB $141.99</option>
        </select><br />
        Hard Drive: <br />
        <select name="Hard Drive" form="form1">
          <option value="WD Blue 1TB $54.99">WD Blue 1TB $54.99</option>
          <option value="WD Blue 2TB $89.30">WD Blue 2TB $89.30</option>
        </select><br />
        CPU: <br />
        <select name="CPU" form="form1">
          <option value="Intel Core i5-8400 $295.00">Intel Core i5-8400 $295.00</option>
          <option value="Intel 7th Gen Core i7-7700K $482.95">Intel 7th Gen Core i7-7700K $482.95</option>
        </select><br />
        Monitor: <br />
        <select name="monitor" form="form1">
          <option value="ASUS VP249HE Eye Care Monitor 23.8 $169.99">ASUS VP249HE Eye Care Monitor 23.8 $169.99</option>
          <option value="ASUS VG278Q 27 FHD $389.99">ASUS VG278Q 27 FHD $389.99</option>
        </select><br />
        OS: <br />
        <select name="os" form="form1">
          <option value="Windows 10 Home $37.38">Windows 10 Home $37.38</option>
          <option value="Linux $0">Linux $0</option>
        </select><br />
            
        Sound Card: <br />
        <select name="sound" form="form1">
          <option value="Creative Sound Blaster Audigy RX 7.1 $89.99">Creative Sound Blaster Audigy RX 7.1 $89.99</option>
          <option value="Creative Sound Blaster Audigy FX 5.1 $59.99">Creative Sound Blaster Audigy FX 5.1 $59.99</option>
        </select><br />
            <br />
        <asp:Button id="button3" runat="server" Text="Add to Cart" OnClick="button3Clicked" />
            
        
  </form> 
        <h3 runat="server" id="price_spot"></h3>
        
</body>