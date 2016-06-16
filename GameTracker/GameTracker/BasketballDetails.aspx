<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BasketballDetails.aspx.cs" Inherits="COMP2007_S2016_Lesson5C.StudentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Basketball Game Details</h1>
                <h5>All Fields are Required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="teamName1TextBox">Team One Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="teamName1TextBox" placeholder="Team One Name" required="true"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label class="control-label" for="teamName2TextBox">Team Two Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="teamName2TextBox" placeholder="Team Two Name" required="true"></asp:TextBox>
                </div>
            
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" CssClass="btn btn-warning btn-lg" runat="server" 
                        UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" CssClass="btn btn-primary btn-lg" runat="server" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
