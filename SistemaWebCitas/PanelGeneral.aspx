<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="PanelGeneral.aspx.cs" Inherits="SistemaWebCitas.PanelGeneral" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
  function saludar() {
    fetch("PanelGeneral.aspx/Saludar", {
      method: "POST",
      headers: {
        "Content-Type": "application/json"
      },
      body: JSON.stringify({ nombre: "Héctor" })
    })
    .then(res => res.json())
    .then(data => {
      alert(data.d); // ASP.NET encapsula el resultado en "d"
    })
    .catch(error => {
      console.error("Error:", error);
    });
        }

        function saludarAjax() {
            $.ajax({
                url: 'PanelGeneral.aspx/Saludar',      // WebMethod
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                dataType: 'json',                     // ← obliga a jQuery a deserializar
                data: JSON.stringify({ nombre: 'Héctor' }),
                success: function (resp) {
                    // ASP.NET serializa el resultado bajo la propiedad "d"
                    alert(resp.d);
                },
                error: function (xhr, status, err) {
                    console.error('Error:', err);
                }
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<button type="button" onclick="saludar()">Saludar</button>
    <button type="button" onclick="saludarAjax()">Saludar (AJAX)</button>

</asp:Content>
