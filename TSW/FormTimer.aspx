<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormTimer.aspx.cs" Inherits="TSW.FormTimer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
         <style>
.button {
  background-color: #4CAF50; /* Green */
  border: none;
  color: white;
  padding: 14px 80px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 18px;
  margin: 4px 2px;
  cursor: pointer;
}

.button4 {border-radius: 12px;}
</style>
</head>
<body>
    <form id="form1" runat="server">
         <center>
       <asp:ScriptManager ID="Scriptmanager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

   <div class="col-md-3"></div>
	<div runat="server" class="col-md-6 well">
		<h3 class="text-primary">Simple Stopwatch</h3>
		<hr style="border-top:1px dotted #ccc;"/>
		 <asp:Label ID="Label1" runat="server" style="font-size:72px" Text="00:00:00"></asp:Label>  	 
        <br />
            <div style="text-align:center;">                      
            <asp:Timer ID="tm1" Interval="1000" runat="server" OnTick="tm1_Tick" />
            <asp:Button ID="btnStart" Text="Start" BackColor="YellowGreen" CssClass="button button4" runat="server"  OnClick="Start" />
            <asp:Button ID="btnStop" Text="Stop" BackColor="Red" CssClass="button button4" runat="server" OnClick="Stop"/>
            <asp:Label ID="lblID" runat="server"  Text="" Visible="false"></asp:Label>
            </div>
          </div>
            
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="tm1" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>           
              <center>
    </form>
</body>
</html>
