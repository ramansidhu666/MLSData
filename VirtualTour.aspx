<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VirtualTour.aspx.cs" Inherits="MLSWebService.VirtualTour" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Virtual Tour :: index</title>
    <!-- Bootstrap -->
    <link href="css/bootstrap.css" rel="stylesheet">
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/bootstrap-theme.css" rel="stylesheet">
    <link href="css/bootstrap-theme.min.css" rel="stylesheet">
    <link href="css/font.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
    <link href="css/media-queries.css" rel="stylesheet">
    <script src="http://code.jquery.com/jquery-1.10.2.min.js"></script>
    <!-- Fotorama -->
    <link href="css/fotorama.css" rel="stylesheet">
    <script src="js/fotorama.js"></script>
    <script src="js/jquery-1.11.1.min.js"></script>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
      <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
      <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
   <%-- <div class="header_bg">
        <div class="container">
            <div class="row">
                <figure class="logo">
   <img src="images/logo.png" alt="Virtual Tour" title="Virtual Tour"/>
  
      </figure>
            </div>
        </div>
    </div>
    <div class="detail_bg" id="detailbg"  runat="server">
    --%>
    <div class="container">
        <div class="row">
            <div class="col-nd-12">
                <div class="detail_bg" id="detailbg"  runat="server">
                    <div id="Vtour"  runat="server" >
                        <div class="fotorama" data-keyboard="true" data-nav="thumbs"
                            data-loop="true" data-navposition="bottom" data-swipe="true" data-allowfullscreen="true" data-autoplay="2000"
                            data-width="100%" data-height="530px" data-max-width="100%">
                            <asp:Repeater ID="rptImages" runat="server">
                                <ItemTemplate>
                                   <img src="<%#Eval("ImagePath") %>">
                                </ItemTemplate>
                            </asp:Repeater>
                         <%--  <img src="images/slide-1.png">
                          <img src="images/slide-2.png">
                          <img src="images/slide-3.png">
                          <img src="images/slide-1.png">
                          <img src="images/slide-2.png">
                          <img src="images/slide-3.png">--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="js/bootstrap.js"></script>
<script src="js/bootstrap.min.js"></script>
</body>
</html>
