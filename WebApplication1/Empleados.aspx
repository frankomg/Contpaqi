<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empleados.aspx.cs" Inherits="WebApplication1.Empleados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <title>Empleados</title>
     <meta charset="UTF-8" />
     <meta name="viewport" content="width=device-width" />
     <meta name="viewport" content="initial-scale = 1.0, maximum-scale = 1.0, user-scalable = no, width = device-width" />
      
     <link href="css/site.css" type="text/css" rel="stylesheet" media="screen" />
     <script src="js/site.js"  type="text/javascript"></script>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/7.8.0/sweetalert2.min.css" rel="stylesheet" />
     <script src="https://cdnjs.cloudflare.com/ajax/libs/limonte-sweetalert2/7.8.0/sweetalert2.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <h1>EMPLEADOS</h1>
        <div class="tabla">
            <div class="fila">
                <div class="col" style="width:25%">
                    <label for="txtnombre">Nombre: </label>
                    <input id="txtnombre" runat="server" type="text"  required="required" />
                </div>
                <div class="col" style="width:25%">
                    <label for="txtarea">Puesto: </label>
                    <input id="txtpuesto" runat="server" type="text" required="required" />
                </div>
                <div class="col" style="width:25%">
                    <label for="txtsalario">Salario: </label>
                    <input id="txtsalario" runat="server" type="number" required="required" />
                </div>
                <div class="col" style="width:25%">                    
                    <input id="btnagregar" runat="server" type="submit" onserverclick="Insert_Empleado" value="Agregar Empleado"  />
                </div>
            </div>
            <div class="fila" style="height:30px">
                &nbsp;
            </div>
            <div class="fila">
                <div class="col" style="width:100%">
                     <asp:gridview id="grdempleados" AutoGenerateColumns="false" emptydatatext="Datos no disponibles." runat="server" DataKeyNames="id" >
                        <Columns>
                            <asp:BoundField Visible="false" DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True"  />
                            <asp:BoundField HeaderStyle-Width="300px"  DataField="nombre" HeaderText="NOMBRE" />
                            <asp:BoundField HeaderStyle-Width="200px" DataField="puesto" HeaderText="PUESTO" />
                            <asp:BoundField HeaderStyle-Width="120px" DataField="salario" HeaderText="SALARIO_MXN" />
                            <asp:BoundField HeaderStyle-Width="120px" DataField="salarioUSD" HeaderText="SALARIO_USD" />
                        </Columns>
                    </asp:gridview>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
