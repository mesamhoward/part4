<%@ Page Language="C#" Inherits="store_part3.contact" %>
<!DOCTYPE html>
<html>
<head runat="server">
	<title>contact</title>
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

  <div class="banner-image">
    <div class="banner-text">
      <h3>Computer Store</h3>
      <p> Contact Us</p>
    </div>
  </div>
	<form id="form1" runat="server">
            
    
    <label for="fname">Name</label>
    <input type="text" id="fname" name="firstname" placeholder="Your name..">
    

    <label for="subject">Subject</label>
    <textarea id="subject" name="subject" placeholder="Write something.." style="height:200px"></textarea>
    <br />
    <br />
    <input type="submit" value="Submit">
	</form>
        
    
  
</body>
</html>
