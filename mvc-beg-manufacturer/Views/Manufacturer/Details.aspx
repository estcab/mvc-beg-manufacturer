<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<mvc_beg_manufacturer.Models.Manufacturer>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Manufacturer's Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details of <%= Model.ManufacturerName %></h2>

    <p> 
        Country: <%= Model.ManufacturerCountry %><br />  
        Email: <%= Model.ManufacturerEmail %><br />    
        WebSite: <%= Model.ManufacturerWebsite %> <br />
    </p>

    <p>
        <a href="/Manufacturer">Back To List</a>
    </p>
    
</asp:Content>
