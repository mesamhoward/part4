<%@ Page Language="C#" Inherits="store_part3.orders" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <title>My Orders</title>
    <link id="callCss" rel="stylesheet" href="css/bootstrap.min.css" media="screen"/>

</head>
<body>
    
    
  <nav class="topnav">
    <h4> <a class="btn" href="Default.aspx">Home</a>
      <a class="btn" href="contact.aspx"> Contact</a>
      <a class="btn" href="checkout.aspx"> Checkout</a>
      <a class="btn" href="orders.aspx"> My orders</a>
      <form id="form9" runat="server">
  <asp:Button id="button14" class="btn cancel" runat="server" Text="Logout" onclick="logout" />
  <asp:Button id="button15" class="btn cancel" runat="server" Text="Edit Order" onclick="edit" /></form>
    </h4>

  </nav>

  <div class="banner-image">
    <div class="banner-text">
      <h3>Computer Store</h3>
      <p runat="server" id="display"> </p>
    </div>
  </div>
  <p  runat="server" id="products"></p>
        
        
  <div class="form-popup" >
  <form id="myForm" class="form-container" action="orders.aspx" runat="server" method="post">
    <h1>Login</h1>

    <label for="User"><b>User</b></label>
    <input type="text" placeholder="Enter Username" id="user1" runat="server">

    <label for="psw"> <b>Password</b> </label>
    <input type="password" placeholder="Enter Password" id="psw" runat="server">

    <br />
    
    <asp:Button id="button8" type="submit" class="btn" runat="server" Text="Login" onclick="login" /></form>
 
  <form id="form6" runat="server">
  <asp:Button id="button7" class="btn cancel" runat="server" Text="Sign Up" onclick="signForm" />
  <asp:Button id="button13" class="btn cancel" runat="server" Text="Forgot Password" onclick="forgotForm" /></form>
  
</div>

<div class="form-popup" >
<form id="signForm1" runat="server" class="form-container" method="post">
  <h1>Sign Up</h1>

  <label for="user2"><b>User</b></label>
  <input type="text" placeholder="Enter Username" id="user2" runat="server">

  <label for="psw2"><b>Password</b></label>
  <input id="psw2" type="password" placeholder="Enter Password" runat="server">

  <label for="psw3"><b>Retype Password</b></label>
  <input id="psw3" type="password" placeholder="Enter Password" runat="server">
  <br /><br />
  <button type="submit" class="btn">Submit</button>
  
  <asp:Button id="button9" class="btn cancel" runat="server" Text="Back to Login" onclick="logForm" />
</form>
</div>

<div class="form-popup" >
<form id="forgot" runat="server" class="form-container" method="post">
  <h1>Forgot Password</h1>

  <label for="user4"><b>User</b></label>
  <input type="text" placeholder="Enter Username" id="user4" runat="server">

  <label for="email"><b>Email</b></label>
  <input id="email"  placeholder="Enter Email" runat="server">

  
  <br /><br />
  
  <asp:Button id="button18" class="btn cancel" runat="server" Text="Submit" onclick="forg" />
  
  <asp:Button id="button12" class="btn cancel" runat="server" Text="Back to Login" onclick="logForm" />
</form>
</div>
        
<h5 runat="server" id="error"></h5>
        
        
 
        
        

  </body>
</html>
