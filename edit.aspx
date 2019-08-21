<%@ Page Language="C#" Inherits="store_part3.edit" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Edit</title>
    <script runat="server">
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <select runat='server' id='list1'></select>
        <br /><br />
        <asp:Button id="button3" runat="server" Text="Delete" OnClick="del" />
        <asp:Button id="button4" runat="server" Text="Reconfigure" OnClick="config" />
        <asp:Button id="button5" runat="server" Text="Cancel" OnClick="cancel" />
    </form>
        
     <form id="form2" runat="server" >
        Ram: <br />
        <select runat="server" id="ram" form="form2">
          <option value="G.SKILL Ripjaws V Series 8GB $99.99">G.SKILL Ripjaws V Series 8GB $99.99</option>
          <option value="G.SKILL TridentZ RGB Series 16GB $141.99">G.SKILL TridentZ RGB Series 16GB $141.99</option>
        </select><br />
        Hard Drive: <br />
        <select runat="server" id="drive" form="form2">
          <option value="WD Blue 1TB $54.99">WD Blue 1TB $54.99</option>
          <option value="WD Blue 2TB $89.30">WD Blue 2TB $89.30</option>
        </select><br />
        CPU: <br />
        <select runat="server" id="cpu" form="form2">
          <option value="Intel Core i5-8400 $295.00">Intel Core i5-8400 $295.00</option>
          <option value="Intel 7th Gen Core i7-7700K $482.95">Intel 7th Gen Core i7-7700K $482.95</option>
        </select><br />
        Monitor: <br />
        <select runat="server" id="monitor" form="form2">
          <option value="ASUS VP249HE Eye Care Monitor 23.8 $169.99">ASUS VP249HE Eye Care Monitor 23.8 $169.99</option>
          <option value="ASUS VG278Q 27 FHD $389.99">ASUS VG278Q 27 FHD $389.99</option>
        </select><br />
        OS: <br />
        <select runat="server" id="os" form="form2">
          <option value="Windows 10 Home $37.38">Windows 10 Home $37.38</option>
          <option value="Linux $0">Linux $0</option>
        </select><br />
            
        Sound Card: <br />
        <select runat="server" id="sound" form="form2">
          <option value="Creative Sound Blaster Audigy RX 7.1 $89.99">Creative Sound Blaster Audigy RX 7.1 $89.99</option>
          <option value="Creative Sound Blaster Audigy FX 5.1 $59.99">Creative Sound Blaster Audigy FX 5.1 $59.99</option>
        </select><br />
            <br />
        <asp:Button id="button20" runat="server" Text="Change" OnClick="button4Clicked" />
            
        
  </form> 
        <h3 runat="server" id="price_spot"></h3>
        
    
    
    <p id = "sel" runat="server"></p>
        
    
</body>
</html>

