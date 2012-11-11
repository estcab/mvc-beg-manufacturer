<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" 
Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Crear
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Nuevo Fabricante</h2>

    <form action="/Manufacturer/Guardar" method="post">
        Name: <input type="text" name="ManufacturerName" id="ManufacturerName" />
        Country: <input type="text" name="ManufacturerCountry" id="ManufacturerCountry" /><br />
        <input type="submit" name="submit" id="submit" />
    </form>

</asp:Content>
