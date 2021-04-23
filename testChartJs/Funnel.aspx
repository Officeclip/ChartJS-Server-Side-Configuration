<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Funnel.aspx.cs" Inherits="testChartJs.Funnel" %>

<html>

<head runat="server">
    <title></title>
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.13.0/moment.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.6.0/Chart.min.js"></script>
    <script src="chart.funnel.bundled.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div style="width: 800px; height: 800px">
            <canvas id="myChart"></canvas>
        </div>
         <script type="text/javascript">
             var ctx = $("#myChart").get(0).getContext("2d");
             var config = <%= chartConfigString %>;
             var chart = new Chart(ctx, config);
         </script>  
    </form>
 
</body>
</html>