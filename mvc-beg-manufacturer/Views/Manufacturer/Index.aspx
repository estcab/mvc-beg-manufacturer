<%@ Page Title="" Language="C#" 
    MasterPageFile="~/Views/Shared/Site.Master" 
    Inherits="System.Web.Mvc.ViewPage<IDictionary<int, string>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Fabricantes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Lista de Fabricantes</h2>
    <% if (Model != null)
       {%>
    <ul>
        <% foreach (var item in Model)
           {
        %>
        <li><a href="/Manufacturer/Details/<%= Html.Encode(item.Key)%>">
               <%= Html.Encode(item.Value) %></a></li>
        <% }%>
    </ul>
    <% } %>

    <a href="/Manufacturer/Crear">Añadir Fabricante...</a>

</asp:Content>
