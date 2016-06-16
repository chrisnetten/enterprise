<%@ Page Title="Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Basketball.aspx.cs" Inherits="COMP2007_S2016_Lesson5C.Students" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Student List</h1>
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i>Add Student</a>

             

                <asp:GridView runat="server" CssClass="table table-bordered table-striped table-hover"
                    ID="BasketballGridView" AutoGenerateColumns="false" DataKeyNames="basketballID"
                    AllowPaging="true" PageSize="3"
                    AllowSorting="true"
                   >
                    <Columns>
                        <asp:BoundField DataField="basketballtID" HeaderText="Basketball ID" Visible="true" SortExpression="basketballID" />
                        <asp:BoundField DataField="teamName1" HeaderText="TeamName1" Visible="true" SortExpression="teamName1" />
                        <asp:BoundField DataField="teamNAme2" HeaderText="TeamName2" Visible="true" SortExpression="teamName1" />
                    
                        <asp:HyperLinkField HeaderText="Edit" Text="<i class='fa fa-pencil-square-o fa-lg'></i> Edit" 
                            NavigateUrl="~/BasketballDetails.aspx.cs" ControlStyle-CssClass="btn btn-primary btn-sm" runat="server"
                            DataNavigateUrlFields="basketballID" DataNavigateUrlFormatString="BasketballDetails.aspx?basketballID={0}" />
                        <asp:CommandField  HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete"
                            ShowDeleteButton="true" ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>




</asp:Content>
