<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ddmurthare.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Planet Ddmurthane - May The Force Be With You</title>
    <link href="App_Themes/bootstrap.css" rel="stylesheet" />
    <link href="App_Themes/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-1.10.2.min.js"></script>

</head>
<body>

    <script type="text/javascript">


        function validateData() {

            $("#DisplayResults").load("Forms/ValidateResults.aspx", { "elementVal": document.getElementById("elementVal").value, "symbolVal": document.getElementById("symbolVal").value });

        }

       
    </script>
    <form id="frmDdmurthare" method="post">
        <div class="container">
            <div class="row">
                <div class="col-md-5">
                     <img src="Images/DSTV_d7b13_450x450.png" />
                </div>
                <div class="col-md-2">
                    <p>Element:<br /><input type="text" id="elementVal" name="elementVal" class="text-primary" value="" /></p>
                    <p>Symbol:<br /><input type="text" id="symbolVal" name="symbolVal" class="text-primary" value="" /></p>
                    <p><input type="button" class="btn-primary" value="Validate" onclick="validateData()" /></p>
                
                </div>
            
            </div>

            <div class="row">

                <div class="col-md-7" id="DisplayResults">
                     
                </div>
               
            </div>
    
        </div>
   </form>
</body>
</html>
