<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ManagePhonesWeb.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width,initial-scale=1,user-scalable=0"/>
    <title>登陆</title>
    <link rel="stylesheet" type="text/css" href="../css/weui.min.css"/>
    <link rel="stylesheet" type="text/css" href="../css/style.css"/>
    <script src="../scripts/zepto.min.js"></script>
    <script src="../scripts/views.js"></script>
</head>

<body>
  	<div class="login_container js_container">
    <script type="text/html" id="tpl_toast">
		<div class="page">
			<!-- loading toast -->
			<div id="loadingToast" class="weui_loading_toast" style="display:none;">
				<div class="weui_mask_transparent"></div>
				<div class="weui_toast">
					<div class="weui_loading">
						<div class="weui_loading_leaf weui_loading_leaf_0"></div>
						<div class="weui_loading_leaf weui_loading_leaf_1"></div>
						<div class="weui_loading_leaf weui_loading_leaf_2"></div>
						<div class="weui_loading_leaf weui_loading_leaf_3"></div>
						<div class="weui_loading_leaf weui_loading_leaf_4"></div>
						<div class="weui_loading_leaf weui_loading_leaf_5"></div>
						<div class="weui_loading_leaf weui_loading_leaf_6"></div>
						<div class="weui_loading_leaf weui_loading_leaf_7"></div>
						<div class="weui_loading_leaf weui_loading_leaf_8"></div>
						<div class="weui_loading_leaf weui_loading_leaf_9"></div>
						<div class="weui_loading_leaf weui_loading_leaf_10"></div>
						<div class="weui_loading_leaf weui_loading_leaf_11"></div>
					</div>
					<p class="weui_toast_content">登陆中。。。</p>
				</div>
			</div>
		</div>
		</script>
    
        <form id="form1" runat="server">
        <div class="weui_cells weui_cells_form w">
			<div class="weui_cell">
                <div class="weui_cell_hd"><label class="weui_label">账户</label></div>
                <div class="weui_cell_bd weui_cell_primary">
                    <asp:TextBox  class="weui_input" ID="username" runat="server" Width="404px" TextMode="SingleLine"></asp:TextBox>
                </div>
            </div>
            <div class="weui_cell">
                <div class="weui_cell_hd"><label class="weui_label">密码</label></div>
                <div class="weui_cell_bd weui_cell_primary">
                    <asp:TextBox  class="weui_input" ID="password" runat="server" Width="404px" TextMode="Password"></asp:TextBox>
                </div>
            </div>
       </div>
          
       <div class="weui_btn_area w" style="margin-top:20px;">
           <asp:Button class="weui_btn weui_btn_primary" ID="btnLogin" runat="server" Text="Button" OnClick="btnLogin_Click"/>
       </div>
       </form>
    </div><!--container end-->
</body>
</html>
